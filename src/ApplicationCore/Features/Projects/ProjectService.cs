using ApplicationCore.Data.Context;
using ApplicationCore.Domain;
using ApplicationCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Features.Projects;

public class ProjectService(ApplicationContext context) : IProjectService
{
    public async Task<Response<long?>> Create(ProjectRequestModel request)
    {
        if (!await context.Users.AnyAsync(x => x.Id == request.UserId))
            return new Response<long?>(null, 404, "Usuário não encontrado.");
        
        var project = ProjectAdapter.ToDomain(request);

        try
        {
            await context.Projects.AddAsync(project);
            await context.SaveChangesAsync();

            await BindUserToProject(project.Id, request.UserId);
        }
        catch
        {
            return new Response<long?>(null, 500, "Não foi possível cadastrar tarefa.");
        }

        return new Response<long?>(project.Id);
    }

    public async Task<Response<long?>> BindUserToProject(long projectId, long userId)
    {
        if (!await context.Projects.AnyAsync(x => x.Id == projectId))
            return new Response<long?>(null, 404, "Projeto não encontrado.");

        if (!await context.Users.AnyAsync(x => x.Id == userId))
            return new Response<long?>(null, 404, "Usuário não encontrado.");

        if (await context.UserProjects.AnyAsync(u => u.UserId == userId && u.ProjectId == projectId))
            return new Response<long?>(null, 404, "Usuário já está vinculado ao projeto.");

        try
        {
            await context.UserProjects.AddAsync(new UserProject(userId, projectId));
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new Response<long?>(null, 500, ex.Message);
        }

        return new Response<long?>(userId);
    }

    public async Task<Response<ProjectResponseModel>> GetById(long id)
    {
        var project = await context.Projects
            .AsNoTracking()
            .Include(x => x.Tasks)
            .Include(x => x.ProjectUsers)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);

        return project is null
            ? new Response<ProjectResponseModel>(null, 404, "Projeto não encontrado.")
            : new Response<ProjectResponseModel>(ProjectAdapter.FromDomain(project));
    }
}