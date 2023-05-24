using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Authentication
{
    public class LoginRequestByEmailDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
