using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.EmailDTO
{
    public  class EmailOptions
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
    }
}
