using ApplicationCore.Data.Context;
using ApplicationCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Responses;

namespace ApplicationCore.Features.Users;

public class UserService(ApplicationContext context) : IUserService
{
    private readonly DbSet<User> _dbSet = context.Set<User>();
    
    public async Task<Response<long?>> Create(UserRequestModel request)
    {
        var user = UserAdapter.ToDomain(request);
        
        try
        {
            await _dbSet.AddAsync(user);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new Response<long?>(null, 500, "Não foi possível cadastrar usuário.");
        }
        
        return new Response<long?>(user.Id);
    }

    public async Task<Response<UserResponseModel>> GetById(long id)
    {
        var response = UserAdapter.FromDomain(
            (await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id))!);
        
        return response is null
            ? new Response<UserResponseModel>(default, 404, "Usuário não encontrado.")
            : new Response<UserResponseModel>(response);
    }
    
    public async Task<Response<IEnumerable<UserResponseModel>>> GetAll() =>
        new((await _dbSet
            .AsNoTracking()
            .ToListAsync()
        ).Select(UserAdapter.FromDomain));
}