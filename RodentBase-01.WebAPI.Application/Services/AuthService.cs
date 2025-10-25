using RodentBase_01.WebAPI.Application.Contracts.Application;
using RodentBase_01.WebAPI.Application.DTOs.Auth;

namespace RodentBase_01.WebAPI.Application.Services;

public class AuthService : IAuthService
{
    public AuthService()
    {

    }

    public Task<string> AuthenticateUserAsync(UserLoginDto userLoginDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterUserAsync(UserRegisterDto userRegisterDto)
    {
        throw new NotImplementedException();
    }
}
