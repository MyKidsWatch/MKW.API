﻿using MimeKit;

namespace MKW.Domain.Dto.DTO.EmailDTO
{
    public class BaseMessageEmailDTO
    {
        public List<MailboxAddress> SendTo { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
