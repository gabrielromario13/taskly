using ApplicationCore.Responses;

namespace ApplicationCore.Features.Tasks;

public interface ITaskService
{
    Task<Response<long?>> Create(TaskRequestModel request);
    Task<Response<TaskResponseModel>> GetById(long id);
}