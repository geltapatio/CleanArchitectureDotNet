using CleanArchitecture.DotNet6.Application.Models.Mail;

namespace CleanArchitecture.DotNet6.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
