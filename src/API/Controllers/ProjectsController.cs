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
        
        return result.Data is null
            ? BadRequest(result)
            : Created($"{Request.Path}/{result.Data}", string.Empty);
    }
    
    [HttpPost("{projectId:long}/users/{userId:long}")]
    public async Task<IActionResult> BindUserToProject(long projectId, long userId)
    {
        var result = await projectService.BindUserToProject(projectId, userId);
        
        return result.Data is null
            ? NotFound(result)
            : Created($"{Request.Path}", string.Empty);
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await projectService.GetById(id);
        
        return result.Data is null
            ? NotFound(result)
            : Ok(result);
    }
}