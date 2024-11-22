using ApplicationCore.Domain.Enums;
using ApplicationCore.Features.Projects;

namespace ApplicationCore.Domain.Models;

public class Project(
    string name,
    string description,
    DateTime startDate,
    DateTime? endDate,
    Status status,
    Priorities priority,
    long ownerId) : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public DateTime StartDate { get; private set; } = startDate;
    public DateTime? EndDate { get; private set; } = endDate;
    public Status Status { get; private set; } = status;
    public Priorities Priority { get; private set; } = priority;
    public long OwnerId { get; private set; } = ownerId;

    public virtual ICollection<UserProject> ProjectUsers { get; set; } = [];
    public virtual ICollection<Task> Tasks { get; set; } = [];

    public void Update(ProjectRequestModel request)
    {
        Name = request.Name;
        Description = request.Description;
        StartDate = request.StartDate;
        EndDate = request.EndDate;
        Status = request.Status;
        Priority = request.Priority;
        OwnerId = request.UserId;
    }
}