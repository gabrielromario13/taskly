using ApplicationCore.Data.Context;
using ApplicationCore.Domain;
using ApplicationCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Features.Projects;

public class ProjectService(ApplicationContext context) : IProjectService
{
    public async Task<Response<long?>> Create(ProjectRequestModel request)
    {
        var project = ProjectAdapter.ToDomain(request);

        try
        {
            await context.Projects.AddAsync(project);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<long?>(null, 500, "Não foi possível cadastrar tarefa.");
        }

        return new Response<long?>(project.Id);
    }

    public async Task<Response<(long, long)?>> BindUserToProject(long userId, long projectId)
    {
        if (!await context.Projects.AnyAsync(x => x.Id == projectId))
            return new Response<(long, long)?>(null, 404, "Projeto não encontrado.");

        if (!await context.Users.AnyAsync(x => x.Id == userId))
            return new Response<(long, long)?>(null, 404, "Usuário não encontrado.");

        if (await context.UserProjects.AnyAsync(u => u.UserId == userId && u.ProjectId == projectId))
            return new Response<(long, long)?>(null, 404, "Usuário já está vinculado ao projeto.");

        try
        {
            await context.UserProjects.AddAsync(new UserProject(userId, projectId));
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new Response<(long, long)?>(null, 500, ex.Message);
        }

        return new Response<(long, long)?>((projectId, userId));
    }

    public async Task<Response<ProjectResponseModel>> GetById(long id)
    {
        var project = await context.Projects
            .AsNoTracking()
            .Include(x => x.Tasks)
            .Include(x => x.ProjectUsers)
            .ThenInclude(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (project is null)
            return new Response<ProjectResponseModel>(null, 404, "Projeto não encontrado.");

        return project.Tasks.Count <= 0
            ? new Response<ProjectResponseModel>(null, 404, "Nenhuma tarefa encontrada.")
            : new Response<ProjectResponseModel>(ProjectAdapter.FromDomain(project));
    }
}