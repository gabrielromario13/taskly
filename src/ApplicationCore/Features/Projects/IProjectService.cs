using ApplicationCore.Domain;

namespace ApplicationCore.Features.Projects;

public interface IProjectService
{
    Task<Response<long?>> Create(ProjectRequestModel request);
    Task<Response<(long, long)?>> BindUserToProject(long userId, long projectId);
    Task<Response<ProjectResponseModel>> GetById(long id);
}