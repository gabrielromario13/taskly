namespace ApplicationCore.Features.TaskComments;

public class TaskCommentModel
{
    public string Content { get; set; } = string.Empty;
    public long TaskId { get; set; }
    public long UserId { get; set; }
}