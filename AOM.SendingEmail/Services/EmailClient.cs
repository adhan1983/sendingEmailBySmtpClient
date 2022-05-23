using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AOM.SendingEmail.ClientEmail.Dtos;
using AOM.SendingEmail.ClientEmail.Settings;
using AOM.SendingEmail.ClientEmail.Interfaces.Services;

namespace AOM.SendingEmail.ClientEmail.Services
{
    public class EmailClient : IEmailClient
    {
        private readonly IEmailSettings _emailSettings;
        public EmailClient(IEmailSettings emailSettings) => _emailSettings = emailSettings;
        public async Task SendEmail(EmailClientDto email)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email.EmailAddress) ? _emailSettings.ToEmail : email.EmailAddress;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, _emailSettings.DisplayName),
                    Subject = email.Subject,
                    Body = email.Message,
                    IsBodyHtml = true,
                    Priority = MailPriority.High
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
