using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class RequestCheckEmailDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [EmailAddress(ErrorMessage = "The field {0} is invalid")]
        public string Email { get; set; }
    }
}
