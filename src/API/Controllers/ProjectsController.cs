using ApplicationCore.Features.Projects;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(ProjectRequestModel request)
    {
        var result = await projectService.Create(request);
        
        return result is null
            ? BadRequest(result)
            : Ok(result);
    }
    
    [HttpPost("{projectId:long}/users/{userId:long}")]
    public async Task<IActionResult> BindUserToProject(long projectId, long userId)
    {
        var result = await projectService.BindUserToProject(projectId, userId);
        
        return result is null
            ? NotFound(result)
            : Ok(result);
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await projectService.GetById(id);
        
        return result is null
            ? NotFound(result)
            : Ok(result);
    }
}