using ApplicationCore.Features.TaskComments;

namespace ApplicationCore.Domain.Models;

public class TaskComment(string content, long taskId, long userId) : BaseEntity
{
    public string Content { get; private set; } = content;
    public long TaskId { get; private set; } = taskId;
    public long UserId { get; private set; } = userId;

    public void Update(TaskCommentModel model)
    {
        Content = model.Content;
        TaskId = model.TaskId;
        UserId = model.UserId;
    }
}