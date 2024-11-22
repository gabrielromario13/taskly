using ApplicationCore.Features.Tasks;
using ApplicationCore.Features.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(ITaskService taskService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(TaskRequestModel request)
    {
        var result = await taskService.Create(request);
        
        return result.Data is null
            ? BadRequest(result)
            : Created($"{Request.Path}/{result.Data}", string.Empty);
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