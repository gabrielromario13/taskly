using ApplicationCore.Features.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(UserRequestModel request)
    {
        var result = await userService.Create(request);
        
        return result is null
            ? BadRequest(result)
            : Ok(result);
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await userService.GetById(id);
        
        return result is null
            ? NotFound(result)
            : Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await userService.GetAll());
}