using ApplicationCore.Domain.Enums;
using ApplicationCore.Features.Tasks;

namespace ApplicationCore.Domain.Models;

public class Task(string title, string description, Priorities priority, Status status, long? userId, long projectId)
    : BaseEntity
{
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public Priorities Priority { get; private set; } = priority;
    public Status Status { get; private set; } = status;
    public long? UserId { get; private set; } = userId == 0 ? null : userId;
    public long ProjectId { get; private set; } = projectId;

    public void Update(TaskRequestModel request)
    {
        Title = request.Title;
        Description = request.Description;
        Priority = request.Priority;
        Status = request.Status;
        UserId = request.UserId;
        ProjectId = request.ProjectId;
    }
}