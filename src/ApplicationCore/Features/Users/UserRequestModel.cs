using ApplicationCore.Domain.Enums;

namespace ApplicationCore.Features.Users;

public class UserRequestModel
{
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? LastLogin { get; set; }
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public Roles Role { get; set; }
}