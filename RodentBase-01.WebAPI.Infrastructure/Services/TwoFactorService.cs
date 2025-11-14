using RodentBase_01.WebAPI.Application.Contracts.Infrastructure.Services;
using RodentBase_01.WebAPI.Infrastructure.Contracts;

namespace RodentBase_01.WebAPI.Infrastructure.Services;

public sealed class TwoFactorService : ITwoFactorService
{
    private readonly IEmailSenderService _emailSenderService;
    private readonly ICodeStorage _codeStorage;

    public TwoFactorService(IEmailSenderService emailSenderService, ICodeStorage codeStorage)
    {
        _emailSenderService = emailSenderService;
        _codeStorage = codeStorage;
    }

    public async Task<bool> SendCodeAsync(Guid userId, string email)
    {
        var code = new Random().Next(100000, 999999).ToString();
        await _codeStorage.StoreCodeAsync(userId, code, TimeSpan.FromMinutes(10));

        return await _emailSenderService.SendEmailAsync(email, "Your 2FA code", $"Your two-factor authentication code is: {code}");
    }

    public async Task<bool> ValidateCodeAsync(Guid userId, string code)
    {
        return await _codeStorage.ValidateCodeAsync(userId, code);
    }
}