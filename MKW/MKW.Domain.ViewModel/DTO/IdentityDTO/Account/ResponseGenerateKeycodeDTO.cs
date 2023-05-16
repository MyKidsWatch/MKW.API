using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class ResponseGenerateKeycodeDTO
    {
        public ResponseGenerateKeycodeDTO(bool isKeycodeSent)
        {
            IsKeycodeSent = isKeycodeSent;
        }
        public bool IsKeycodeSent { get;}
    }
}
