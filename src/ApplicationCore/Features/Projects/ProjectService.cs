using ApplicationCore.Data.Context;
using ApplicationCore.Domain.Models;
using ApplicationCore.Features.Tasks;
using ApplicationCore.Responses;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Features.Projects;

public class ProjectService(ApplicationContext context) : IProjectService
{
    private readonly DbSet<Project> _dbSet = context.Set<Project>();
    
    public async Task<Response<long?>> Create(ProjectRequestModel request)
    {
        var project = ProjectAdapter.ToDomain(request);
        
        try
        {
            await _dbSet.AddAsync(project);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<long?>(null, 500, "Não foi possível cadastrar tarefa.");
        }
        
        return new Response<long?>(project.Id);
    }

    public async Task<Response<ProjectResponseModel>> GetById(long id)
    {
        var model = ProjectAdapter.FromDomain(
            (await _dbSet
                .AsNoTracking()
                .Include(x => x.Tasks)
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Id == id))!);
        
        return model is null
            ? new Response<ProjectResponseModel>(default, 404, "Tarefa não encontrada.")
            : new Response<ProjectResponseModel>(model);
    }
}