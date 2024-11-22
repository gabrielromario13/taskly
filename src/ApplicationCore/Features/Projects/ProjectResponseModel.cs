using ApplicationCore.Features.Tasks;
using ApplicationCore.Features.Users;

namespace ApplicationCore.Features.Projects;

public class ProjectResponseModel
{
    public long Id { get; set; }
    public long OwnerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public IEnumerable<TaskResponseModel>? Tasks { get; set; } = [];
    public IEnumerable<UserResponseModel>? Users { get; set; } = [];
}