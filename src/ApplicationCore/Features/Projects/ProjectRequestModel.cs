using ApplicationCore.Domain.Enums;

namespace ApplicationCore.Features.Projects;

public class ProjectRequestModel : ProjectBaseModel
{
    public Status Status { get; set; }
    public Priorities Priority { get; set; }
    public long UserId { get; set; }
}