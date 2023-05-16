using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Auth
{
    public class LoginRequestByUserNameDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(12, ErrorMessage = "Max length 12")]
        [MinLength(3, ErrorMessage = "Min length 2")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
