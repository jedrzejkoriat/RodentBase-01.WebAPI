namespace RodentBase_01.WebAPI.Application.Contracts.Infrastructure.Services;

public interface ITwoFactorService
{
    Task<bool> SendCodeAsync(Guid userId, string email);
    Task<bool> ValidateCodeAsync(Guid userId, string code);
}
