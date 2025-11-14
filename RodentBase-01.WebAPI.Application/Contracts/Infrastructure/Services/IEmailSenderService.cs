namespace RodentBase_01.WebAPI.Application.Contracts.Infrastructure.Services;

public interface IEmailSenderService
{
    public Task<bool> SendEmailAsync(string to, string subject, string body);
}
