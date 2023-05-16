using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class ConfirmAccountEmailDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Keycode { get; set; }
    }
}
