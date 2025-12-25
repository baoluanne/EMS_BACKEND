using EMS.Domain.Interfaces.EmailServices;
using EMS.Domain.Models;
using Hangfire;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EMS.Infrastructure.EmailServices;

public class EmailService(IOptions<MailSettings> options) : IEmailService
{
    private readonly MailSettings _emailSettings = options.Value;

    public bool SendMail(MailData mailData)
    {
        BackgroundJob.Enqueue(() => HandleSendEmailAsync(mailData));

        return true;
    }

    private async Task<bool> HandleSendEmailAsync(MailData mailData)
    {
        var emailMessage = new MimeMessage();

        var emailFrom = new MailboxAddress(_emailSettings.Name, _emailSettings.EmailId);
        emailMessage.From.Add(emailFrom);

        var emailTo = new MailboxAddress(mailData.ToName, mailData.ToEmail);
        emailMessage.To.Add(emailTo);

        emailMessage.Subject = mailData.Subject;

        var emailBodyBuilder = new BodyBuilder
        {
            HtmlBody = mailData.Body
        };
        emailMessage.Body = emailBodyBuilder.ToMessageBody();

        var mailClient = new SmtpClient();

        await mailClient.ConnectAsync(_emailSettings.Host, _emailSettings.Port, _emailSettings.UseSSL);
        await mailClient.AuthenticateAsync(_emailSettings.EmailId, _emailSettings.Password);
        await mailClient.SendAsync(emailMessage);

        await mailClient.DisconnectAsync(true);
        mailClient.Dispose();

        return true;
    }
}
