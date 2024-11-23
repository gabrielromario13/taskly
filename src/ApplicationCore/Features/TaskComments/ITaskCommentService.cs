using ApplicationCore.Domain;

namespace ApplicationCore.Features.TaskComments;

public interface ITaskCommentService
{
    Task<Response<long?>> Create(TaskCommentModel request);
    Task<Response<bool>> Update(long id, TaskCommentModel request);
    Task<Response<TaskCommentModel>> GetById(long id);
}