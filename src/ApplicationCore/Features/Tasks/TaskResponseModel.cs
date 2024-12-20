using ApplicationCore.Domain.Models;
using ApplicationCore.Features.TaskComments;
using ApplicationCore.Features.Users;

namespace ApplicationCore.Features.Tasks;

public class TaskResponseModel
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public long ProjectId { get; set; }
    public long? AssignedUserId { get; set; } = null!;
    public IEnumerable<TaskCommentModel> TaskComments { get; set; } = [];
}