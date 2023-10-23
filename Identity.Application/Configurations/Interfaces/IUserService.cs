using Identity.Application.Dtos.User;

namespace Identity.Application.Configurations.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginResponse> LoginAsync(UserLoginRequest request);
    }
}