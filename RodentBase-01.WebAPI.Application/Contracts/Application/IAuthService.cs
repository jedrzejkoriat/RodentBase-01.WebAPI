using RodentBase_01.WebAPI.Application.DTOs.Auth;

namespace RodentBase_01.WebAPI.Application.Contracts.Application;

public interface IAuthService
{
    Task<string> AuthenticateUserAsync(UserLoginDto userLoginDto);
    Task<bool> RegisterUserAsync(UserRegisterDto userRegisterDto);
}

