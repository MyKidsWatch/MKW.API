using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class RecoveryPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
