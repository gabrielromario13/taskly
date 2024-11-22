using ApplicationCore.Responses;

namespace ApplicationCore.Features.Projects;

public interface IProjectService
{
    Task<Response<long?>> Create(ProjectRequestModel request);
    Task<Response<ProjectResponseModel>> GetById(long id);
}