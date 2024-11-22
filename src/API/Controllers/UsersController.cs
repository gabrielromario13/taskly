using ApplicationCore.Features.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(UserRequestModel request)
    {
        if (!request.ConfirmPassword.Equals(request.Password))
            return BadRequest(new { code = 400, message = "As senhas precisam ser iguais." });

        var result = await userService.Create(request);

        return result.Data is null
            ? BadRequest(result)
            : Created($"{Request.Path}/{result.Data}", string.Empty);
    }
    
    [HttpPatch("{id:long}")]
    public async Task<IActionResult> Update(long id, UpdateUserRequest request)
    {
        var result = await userService.Update(id, request);

        return result.Data is false
            ? BadRequest(result)
            : NoContent();
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await userService.GetById(id);

        return result.Data is null
            ? NotFound(result)
            : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await userService.GetAll());
}