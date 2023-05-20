using System.ComponentModel.DataAnnotations;

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
