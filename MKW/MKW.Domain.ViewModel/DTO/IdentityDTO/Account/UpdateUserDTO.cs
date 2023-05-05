using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class UpdateUserDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }

        [MaxLength(12, ErrorMessage = "Max length 12")]
        [MinLength(3, ErrorMessage = "Min length 2")]
        public string? userName { get; set; }

        [MaxLength(50, ErrorMessage = "Max length 50")]
        [MinLength(3, ErrorMessage = "Min length 3")]
        public string? FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Max length 50")]
        [MinLength(3, ErrorMessage = "Min length 3")]
        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "The field {0} is invalid")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "The field {0} is invalid")]
        public string? PhoneNumber { get; set; }
    }
}
