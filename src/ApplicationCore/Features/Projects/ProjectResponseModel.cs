using ApplicationCore.Features.Tasks;
using ApplicationCore.Features.Users;

namespace ApplicationCore.Features.Projects;

public class ProjectResponseModel : ProjectBaseModel
{
    public long Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public IEnumerable<UserResponseModel> Users { get; set; } = [];
    public IEnumerable<TaskResponseModel> Tasks { get; set; } = [];
}