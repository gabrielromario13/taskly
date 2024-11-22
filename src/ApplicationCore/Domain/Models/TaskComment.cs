namespace ApplicationCore.Domain.Models;

public class TaskComment(string content, long taskId, long userId) : BaseEntity
{
    public string Content { get; private set; } = content;
    public long TaskId { get; private set; } = taskId;
    public long UserId { get; private set; } = userId;
    
    public virtual Task Task { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}