using ApplicationCore.Features.Projects;
using ApplicationCore.Features.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(ProjectRequestModel request)
    {
        var result = await projectService.Create(request);
        
        return result.Data is null
            ? BadRequest(result)
            : Created($"{Request.Path}/{result.Data}", string.Empty);
    }
    
    [HttpPatch("{id:long}")]
    public async Task<IActionResult> Update(long id, ProjectRequestModel request)
    {
        var result = await projectService.Update(id, request);

        return result.Data is false
            ? BadRequest(result)
            : NoContent();
    }
    
    [HttpPost("{projectId:long}/users/{userId:long}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> BindUserToProject(long projectId, long userId)
    {
        var result = await projectService.BindUserToProject(projectId, userId);
        
        return result.Data is null
            ? BadRequest(result)
            : Created($"{Request.Path}", string.Empty);
    }
    
    [HttpGet("{id:long}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await projectService.GetById(id);
        
        return result.Data is null
            ? NotFound(result)
            : Ok(result);
    }
}