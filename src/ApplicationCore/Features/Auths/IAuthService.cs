using ApplicationCore.Domain;

namespace ApplicationCore.Features.Auths;

public interface IAuthService
{
    Task<Response<LoginUserResponse>> Login(LoginUserRequest request);
}