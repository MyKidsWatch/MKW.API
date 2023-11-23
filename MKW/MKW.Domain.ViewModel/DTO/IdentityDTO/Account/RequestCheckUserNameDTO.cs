using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class RequestCheckUserNameDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(20, ErrorMessage = "Max length 20")]
        [MinLength(3, ErrorMessage = "Min length 2")]
        public string UserName { get; set; }

    }
}
