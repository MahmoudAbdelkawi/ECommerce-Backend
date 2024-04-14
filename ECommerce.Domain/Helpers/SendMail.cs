using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace ECommerce.Domain.Helpers
{
    public class SendMail
    {
        private readonly EmailConfigurations _emailConfig;

        public SendMail(EmailConfigurations emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(List<MailboxAddress> to, string subject, string body)
        {
            Send(mimeMessage(to, subject, body));
        }
        public MimeMessage mimeMessage(List<MailboxAddress>to , string subject, string body) // Mapping
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(to);
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };
            return emailMessage;
        }

        public void Send(MimeMessage message)
        {
            using var client = new SmtpClient();
            try
            {
                Console.WriteLine();
                client.Connect(_emailConfig.SmtpServer, 587, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                Console.WriteLine("#############################");
                Console.WriteLine(_emailConfig.UserName);
                Console.WriteLine(_emailConfig.Password);
                client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                client.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
