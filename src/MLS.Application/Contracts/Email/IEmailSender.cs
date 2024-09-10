using MLS.Application.Models.Email;

namespace MLS.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}