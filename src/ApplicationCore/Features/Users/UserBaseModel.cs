using System.Text.Json.Serialization;

namespace ApplicationCore.Features.Users;

public class UserBaseModel
{
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? LastLogin { get; set; }
}