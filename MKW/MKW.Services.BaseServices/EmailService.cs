using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MKW.Domain.Dto.DTO.EmailDTO;
using MKW.Domain.Interface.Services.BaseServices;

namespace MKW.Services.BaseServices
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void sendEmail(string[] To, string subject, int userId, string token)
        {
            var message = new EmailMessageDTO(To, subject, token, userId);
            var emailMessage = createMessageBody(message);
            sendEmailMessage(emailMessage);
        }

        private MimeMessage createMessageBody(EmailMessageDTO message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("sentoTo", _configuration.GetSection("EmailSettings:From").Value));
            emailMessage.To.AddRange(message.SendTo);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
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
                    client.Connect(_configuration.GetSection("EmailSettings:SmtpServer").Value, int.Parse(_configuration.GetSection("EmailSettings:Port").Value), true);

                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_configuration.GetSection("EmailSettings:From").Value, _configuration.GetSection("EmailSettings:Password").Value);

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
