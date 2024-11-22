using ApplicationCore.Data.Context;
using ApplicationCore.Domain;
using ApplicationCore.Utils;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Features.Auths;

public class AuthService(ApplicationContext context) : IAuthService
{
    public async Task<Response<LoginUserResponse>> Login(LoginUserRequest request)
    {
        var hashPassword = HashUtils.HashPassword(request.Password);

        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Username == request.Username
                                      && x.Password == hashPassword);

        if (user is null)
            return new Response<LoginUserResponse>(null, 404, "Usuário ou senha inválidos.");

        var token = TokenHandler.GenerateToken(user);

        return new Response<LoginUserResponse>(new LoginUserResponse() { Token = token });
    }
}