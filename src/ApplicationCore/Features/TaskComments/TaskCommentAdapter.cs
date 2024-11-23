using ApplicationCore.Domain.Models;

namespace ApplicationCore.Features.TaskComments;

public static class TaskCommentAdapter
{
    public static TaskComment ToDomain(TaskCommentModel model) =>
        new(
            model.Content,
            model.TaskId,
            model.UserId);
    
    public static TaskCommentModel FromDomain(TaskComment taskComment) =>
        new()
        {
            Content = taskComment.Content,
            TaskId = taskComment.TaskId,
            UserId = taskComment.UserId
        };
}