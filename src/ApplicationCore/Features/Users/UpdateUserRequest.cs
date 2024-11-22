using ApplicationCore.Domain.Enums;

namespace ApplicationCore.Features.Users;

public class UpdateUserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public Roles Role { get; set; }
}