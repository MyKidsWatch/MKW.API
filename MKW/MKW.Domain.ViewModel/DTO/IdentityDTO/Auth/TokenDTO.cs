using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Auth
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
