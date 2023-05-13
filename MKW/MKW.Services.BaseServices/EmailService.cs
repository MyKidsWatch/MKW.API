using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MKW.Domain.Dto.DTO.EmailDTO;
using MKW.Domain.Interface.Services.BaseServices;

namespace MKW.Services.BaseServices
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _emailOptions;

        public EmailService( IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public void sendConfirmAccountEmail(string[] To, string subject, string keycode)
        {
            var message = new MessageConfirmEmailDTO(To, subject, keycode);
            var emailMessage = createMessageBody(message);
            sendEmailMessage(emailMessage);
        }

        public void sendRecoveryPasswordEmail(string[] To, string subject, string keycode)
        {
            var message = new MessageRecoveryPasswordDTO(To, subject, keycode);
            var emailMessage = createMessageBody(message);
            sendEmailMessage(emailMessage);
        }

        private MimeMessage createMessageBody(BaseMessageEmailDTO message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("MyKidsWatch", _emailOptions.From));
            emailMessage.To.AddRange(message.SendTo);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message.Content
            };

            return emailMessage;
        }
        private void sendEmailMessage(MimeMessage emailMessage)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailOptions.SmtpServer, _emailOptions.Port, true);

                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_emailOptions.From, _emailOptions.Password);

                    client.Send(emailMessage);
                }
                catch (Exception err)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            };
        }
    }
}
