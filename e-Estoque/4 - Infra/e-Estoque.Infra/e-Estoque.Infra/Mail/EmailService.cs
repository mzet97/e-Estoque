using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace e_Estoque.Infra.Mail
{
    public class EmailService : IEmailService
    {

        public async Task Send(string from, string to, string subject, string body)
        {
            var email = CreateEmail(from, to, subject, body);
            await SendEmail(email);
        }

        private MimeMessage CreateEmail(string from, string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            return email;
        }

        private async Task SendEmail(MimeMessage email)
        {
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("lia4@ethereal.email", "C4QafjTKU1sVysYnzr");
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
