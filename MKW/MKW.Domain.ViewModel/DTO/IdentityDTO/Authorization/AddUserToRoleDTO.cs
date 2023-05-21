using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Authorization
{
    public class AddUserToRoleDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string UserName { get; set; }
    }
}
