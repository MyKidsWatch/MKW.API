using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.EmailDTO
{
    public class EmailMessageDTO
    {
        public List<MailboxAddress> SendTo { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public EmailMessageDTO(IEnumerable<string> sendToList, string subject, string token, int userId)
        {
            SendTo = new List<MailboxAddress>();
            SendTo.AddRange(sendToList.Select(sendToItem => new MailboxAddress("", sendToItem)));
            Subject = subject;
            Content = $"https://localhost:7240/v1/account/confirmEmail?UserId={userId}&ActivationToken={token}";
        }
    }
}
