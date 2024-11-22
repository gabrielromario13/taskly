using ApplicationCore.Domain;

namespace ApplicationCore.Features.Users;

public interface IUserService
{
    Task<Response<long?>> Create(UserRequestModel request);
    Task<Response<bool>> Update(long id, UpdateUserRequest request);
    Task<Response<UserResponseModel>> GetById(long id);
    Task<Response<IEnumerable<UserResponseModel>>> GetAll();
}