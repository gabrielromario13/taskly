using ApplicationCore.Domain;

namespace ApplicationCore.Features.Projects;

public interface IProjectService
{
    Task<Response<long?>> Create(ProjectRequestModel request);
    Task<Response<long?>> BindUserToProject(long projectId, long userId);
    Task<Response<ProjectResponseModel>> GetById(long id);
}