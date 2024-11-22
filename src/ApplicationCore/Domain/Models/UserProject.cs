namespace ApplicationCore.Domain.Models;

public class UserProject(long userId, long projectId)
{
    public long UserId { get; set; } = userId;
    public long ProjectId { get; set; } = projectId;

    public virtual User User { get; set; } = null!;
    public virtual Project Project { get; set; } = null!;
}