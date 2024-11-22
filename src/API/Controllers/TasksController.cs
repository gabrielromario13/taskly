using ApplicationCore.Features.Tasks;
using ApplicationCore.Features.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController(ITaskService taskService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(TaskRequestModel request)
    {
        var result = await taskService.Create(request);
        
        return result is null
            ? BadRequest(result)
            : Ok(result);
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await taskService.GetById(id);
        
        return result is null
            ? NotFound(result)
            : Ok(result);
    }
}