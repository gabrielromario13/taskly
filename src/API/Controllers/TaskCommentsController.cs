using ApplicationCore.Features.TaskComments;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskCommentsController(ITaskCommentService taskCommentService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(TaskCommentModel request)
    {
        var result = await taskCommentService.Create(request);

        return result.Data is null
            ? BadRequest(result)
            : Created($"{Request.Path}/{result.Data}", string.Empty);
    }
    
    [HttpPatch("{id:long}")]
    public async Task<IActionResult> Update(long id, TaskCommentModel request)
    {
        var result = await taskCommentService.Update(id, request);

        return result.Data is false
            ? BadRequest(result)
            : NoContent();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await taskCommentService.GetById(id);

        return result.Data is null
            ? NotFound(result)
            : Ok(result);
    }
}