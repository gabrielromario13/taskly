using ApplicationCore.Domain.Models;
using ApplicationCore.Features.Tasks;
using ApplicationCore.Features.Users;

namespace ApplicationCore.Features.Projects;

public class ProjectAdapter
{
    public static Project ToDomain(ProjectRequestModel request) =>
        new(
            request.Name,
            request.Description,
            request.StartDate,
            request.EndDate,
            request.Status,
            request.Priority,
            request.UserId);
    
    public static ProjectResponseModel FromDomain(Project project) =>
        new()
        {
            Id = project.Id,
            Name = project.Name,
            Description = project.Description,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            Status = project.Status.ToString(),
            Priority = project.Priority.ToString(),
            Tasks = project.Tasks.Select(TaskAdapter.FromDomain),
            Users = project.Users.Select(UserAdapter.FromDomain)
        };
}