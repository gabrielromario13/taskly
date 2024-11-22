namespace ApplicationCore.Domain.Models;

public class Notification(string message, bool isRead, long userId) : BaseEntity
{
    public string Message { get; private set; } = message;
    public bool IsRead { get; private set; } = isRead;
    public long UserId { get; private set; } = userId;
    
    public virtual User User { get; private set; } = null!;
}