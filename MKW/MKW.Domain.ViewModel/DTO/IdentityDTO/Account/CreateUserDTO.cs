using MKW.Domain.Dto.PersonDTO;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(12, ErrorMessage = "Max length 12")]
        [MinLength(3, ErrorMessage = "Min length 2")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "Max length 50")]
        [MinLength(3, ErrorMessage = "Min length 3")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "Max length 50")]
        [MinLength(3, ErrorMessage = "Min length 3")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "The field {0} is invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public PersonOnCreateUserDTO PersonDetails { get; set; }
    }
}
