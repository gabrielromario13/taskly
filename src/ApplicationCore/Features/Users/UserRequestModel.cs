using ApplicationCore.Domain.Enums;

namespace ApplicationCore.Features.Users;

public class UserRequestModel : UserBaseModel
{
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public Roles Role { get; set; }
}