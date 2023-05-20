using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class RequestKeycodeDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
