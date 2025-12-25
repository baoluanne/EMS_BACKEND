using EMS.Domain.Models;

namespace EMS.Domain.Interfaces.EmailServices;

public interface IEmailService
{
    public bool SendMail(MailData mailData);
}
