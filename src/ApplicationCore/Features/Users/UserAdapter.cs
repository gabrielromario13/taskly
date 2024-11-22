using ApplicationCore.Domain.Models;

namespace ApplicationCore.Features.Users;

public static class UserAdapter
{
    public static User ToDomain(UserRequestModel request) =>
        new(
            request.Name,
            request.Username,
            request.Email,
            request.Password,
            request.Role);

    public static UserResponseModel FromDomain(User user) =>
        new()
        {
            Id = user.Id,
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role.ToString(),
            LastLogin = user.LastLogin
        };
}