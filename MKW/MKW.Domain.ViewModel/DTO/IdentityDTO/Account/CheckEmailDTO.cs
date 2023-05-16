using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class CheckEmailDTO
    {
        public CheckEmailDTO(bool isUserNameValid)
        {
            IsEmailValid = isUserNameValid;
        }
        public bool IsEmailValid { get; }
    }
}
