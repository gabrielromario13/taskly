using ApplicationCore.Data.Context;
using ApplicationCore.Features.Common;
using Microsoft.EntityFrameworkCore;
using Task = ApplicationCore.Domain.Models.Task;

namespace ApplicationCore.Features.Tasks;

public class TaskService(ApplicationContext context) : ITaskService
{
    private readonly DbSet<Task> _dbSet = context.Set<Task>();
    
    public async Task<Response<long?>> Create(TaskRequestModel request)
    {
        var task = TaskAdapter.ToDomain(request);
        
        try
        {
            await _dbSet.AddAsync(task);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<long?>(null, 500, "Não foi possível cadastrar tarefa.");
        }
        
        return new Response<long?>(task.Id);
    }

    public async Task<Response<TaskResponseModel>> GetById(long id)
    {
        var response = TaskAdapter.FromDomain(
            (await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id))!);
        
        return response is null
            ? new Response<TaskResponseModel>(default, 404, "Tarefa não encontrada.")
            : new Response<TaskResponseModel>(response);
    }
}