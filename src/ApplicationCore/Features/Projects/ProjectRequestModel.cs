using ApplicationCore.Domain.Enums;

namespace ApplicationCore.Features.Projects;

public class ProjectRequestModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Status Status { get; set; }
    public Priorities Priority { get; set; }
    public long UserId { get; set; }
}