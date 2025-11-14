using RodentBase_01.WebAPI.Application.Contracts.Infrastructure;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace RodentBase_01.WebAPI.Infrastructure.Services;

public sealed class SendGridService : IEmailSenderService
{
    private readonly string _apiKey;
    private readonly string _senderEmail;
    private readonly string _senderName;

    public SendGridService(string apiKey, string senderEmail, string senderName)
    {
        _apiKey = apiKey;
        _senderEmail = senderEmail;
        _senderName = senderName;
    }

    public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress(_senderEmail, _senderName);
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);

        var response = await client.SendEmailAsync(msg);

        return response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK;
    }
}