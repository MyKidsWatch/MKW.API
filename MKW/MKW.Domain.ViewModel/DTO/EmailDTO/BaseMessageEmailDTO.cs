using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.EmailDTO
{
    public class BaseMessageEmailDTO
    {
        public List<MailboxAddress> SendTo { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
