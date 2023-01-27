using Blog23.ViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using Blog23.Services;
using Blog23.Services.Interfaces;

namespace Blog23.Services
{
    public class EmailService : IBlogEmailSender
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
            //_mailSettings = (MailSettings?)mailSettings;
        }

        public Task SendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailSender = _mailSettings.Email ?? Environment.GetEnvironmentVariable("Email");

            MimeMessage newEmail = new()
            {
                Sender = MailboxAddress.Parse(emailSender)
            };

            foreach (var emailAddress in email.Split(";"))
            {
                newEmail.To.Add(MailboxAddress.Parse(emailAddress));
            }

            newEmail.Subject = subject;

            //BodyBuilder emailBody = new()
            //{
            //    HtmlBody = htmlMessage
            //};
            var builder = new BodyBuilder();
            //builder.HtmlBody = $"<b>{name}</b> has sent you an email and can be reached at <b>{emailFrom}</b><br><br>{htmlMessage}";
            newEmail.Body = builder.ToMessageBody();

            using SmtpClient smtpClient = new();

            try
            {
                var host = _mailSettings.Host ?? Environment.GetEnvironmentVariable("Host");
                var port = _mailSettings.Port != 0 ? _mailSettings.Port : int.Parse(Environment.GetEnvironmentVariable("Port")!);
                var password = _mailSettings.Password ?? Environment.GetEnvironmentVariable("Password");

                await smtpClient.ConnectAsync(host, port, SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(emailSender,password);
                await smtpClient.SendAsync(newEmail);
                await smtpClient.DisconnectAsync(true);
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }
    }
}
