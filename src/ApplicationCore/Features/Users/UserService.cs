using ApplicationCore.Data.Context;
using ApplicationCore.Domain;
using ApplicationCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Features.Users;

public class UserService(ApplicationContext context) : IUserService
{
    public async Task<Response<long?>> Create(UserRequestModel request)
    {
        var user = UserAdapter.ToDomain(request);
        
        try
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<long?>(null, 500, "Não foi possível cadastrar usuário.");
        }
        
        return new Response<long?>(user.Id);
    }
    
    public async Task<Response<bool>> Update(long id, UpdateUserRequest request)
    {
        var user = await context.Users.FindAsync(id);

        if (user is null)
            return new Response<bool>(false, 404, "Usuário não encontrado.");
        
        user.Update(request);
        
        try
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
        catch
        {
            return new Response<bool>(false, 500, "Não foi possível atualizar usuário.");
        }
        
        return new Response<bool>(true);
    }

    public async Task<Response<UserResponseModel>> GetById(long id)
    {
        var response = UserAdapter.FromDomain(
            (await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id))!);
        
        return response is null
            ? new Response<UserResponseModel>(default, 404, "Usuário não encontrado.")
            : new Response<UserResponseModel>(response);
    }
    
    public async Task<Response<IEnumerable<UserResponseModel>>> GetAll() =>
        new((await context.Users
            .AsNoTracking()
            .ToListAsync()
        ).Select(UserAdapter.FromDomain));
}