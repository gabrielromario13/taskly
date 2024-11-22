using ApplicationCore.Features.Tasks;
using ApplicationCore.Features.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(ITaskService taskService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(TaskRequestModel request)
    {
        var result = await taskService.Create(request);
        
        return result.Data is null
            ? BadRequest(result)
            : Created($"{Request.Path}/{result.Data}", string.Empty);
    }
    
    [HttpPatch("{id:long}")]
    public async Task<IActionResult> Update(long id, TaskRequestModel request)
    {
        var result = await taskService.Update(id, request);

        return result.Data is false
            ? BadRequest(result)
            : NoContent();
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await taskService.GetById(id);
        
        return result.Data is null
            ? NotFound(result)
            : Ok(result);
    }
}