using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class CheckUserNameDTO
    {
        public CheckUserNameDTO(bool isUserNameValid)
        {
            IsUserNameValid = isUserNameValid;
        }
        public bool IsUserNameValid { get;}

    }
}
