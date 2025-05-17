using MimeKit;
using MailKit.Net.Smtp;

namespace RegistrationApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailSettings:From"]));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            var smtpServer = _config["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_config["EmailSettings:Port"]);
            var smtpUsername = _config["EmailSettings:Username"];
            var smtpPassword = Environment.GetEnvironmentVariable("appPass"); 

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(smtpServer, smtpPort, true);
            await smtp.AuthenticateAsync(smtpUsername, smtpPassword);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
