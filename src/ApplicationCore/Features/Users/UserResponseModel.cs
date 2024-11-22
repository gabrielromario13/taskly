namespace ApplicationCore.Features.Users;

public class UserResponseModel : UserBaseModel
{
    public long Id { get; set; }
    public string Role { get; set; } = string.Empty;
}