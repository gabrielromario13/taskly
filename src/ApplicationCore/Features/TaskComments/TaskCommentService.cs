using ApplicationCore.Data.Context;
using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Features.TaskComments;

public class TaskCommentService(ApplicationContext context) : ITaskCommentService
{
    public async Task<Response<long?>> Create(TaskCommentModel request)
    {
        var taskComment = TaskCommentAdapter.ToDomain(request);
        
        try
        {
            await context.TaskComments.AddAsync(taskComment);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<long?>(null, 500, "Não foi possível cadastrar comentário.");
        }
        
        return new Response<long?>(taskComment.Id);
    }
    
    public async Task<Response<bool>> Update(long id, TaskCommentModel request)
    {
        var taskComment = await context.TaskComments.FindAsync(id);

        if (taskComment is null)
            return new Response<bool>(false, 404, "Comentário não encontrado.");
        
        taskComment.Update(request);
        
        try
        {
            context.TaskComments.Update(taskComment);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<bool>(false, 500, "Não foi possível editar comentário.");
        }
        
        return new Response<bool>(true);
    }

    public async Task<Response<TaskCommentModel>> GetById(long id)
    {
        var response = TaskCommentAdapter.FromDomain(
            (await context.TaskComments
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id))!);
        
        return response is null
            ? new Response<TaskCommentModel>(default, 404, "Comentário não encontrado.")
            : new Response<TaskCommentModel>(response);
    }
}