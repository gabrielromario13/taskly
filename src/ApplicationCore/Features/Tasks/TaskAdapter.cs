using ApplicationCore.Features.Users;
using Task = ApplicationCore.Domain.Models.Task;

namespace ApplicationCore.Features.Tasks;

public static class TaskAdapter
{
    public static Task ToDomain(TaskRequestModel request) =>
        new(
            request.Title,
            request.Description,
            request.Priority,
            request.Status,
            request.UserId,
            request.ProjectId);

    public static TaskResponseModel FromDomain(Task task) =>
        new()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            Priority = task.Priority.ToString(),
            Status = task.Status.ToString(),
            AssignedUserId = task.UserId
        };
}