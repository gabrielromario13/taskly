using ApplicationCore.Domain.Enums;

namespace ApplicationCore.Features.Tasks;

public class TaskRequestModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priorities Priority { get; set; }
    public Status Status { get; set; }
    public long? UserId { get; set; }
    public long ProjectId { get; set; }
}