using Microsoft.Extensions.Options;
using MLS.Application.Contracts.Email;
using MLS.Application.Models.Email;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MLS.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    public EmailSender(IOptions<EmailSetting> emailSetting)
    {
        EmailSetting = emailSetting.Value;
    }

    private EmailSetting EmailSetting { get; }

    public async Task<bool> SendEmail(EmailMessage email)
    {
        var client = new SendGridClient(EmailSetting.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = EmailSetting.FromAddress,
            Name = EmailSetting.FromName
        };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);

        return response.IsSuccessStatusCode;
    }
}