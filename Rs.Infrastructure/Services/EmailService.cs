using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;
using Rs.Domain.Options;

namespace Rs.Infrastructure.Services;

public class EmailService(EmailSettings settings,
    ILogger<EmailService> logger) : IEmailService
{
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var smtpClient = new SmtpClient(settings.SmtpServer)
        {
            Port = settings.SmtpPort,
            Credentials = new NetworkCredential(settings.SmtpUsername, settings.SmtpPassword),
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(settings.SmtpUsername),
            Subject = subject,
            Body = body,            
            IsBodyHtml = true,
        };
        mailMessage.To.Add(to);

        await smtpClient.SendMailAsync(mailMessage);
        logger.LogInformation($"Email successfully sent to {to} with subject '{subject}'.");
    }
}