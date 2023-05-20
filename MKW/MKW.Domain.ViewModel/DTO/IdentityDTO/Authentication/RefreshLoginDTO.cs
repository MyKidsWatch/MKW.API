using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Authentication
{
    public class RefreshLoginDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }
    }
}
