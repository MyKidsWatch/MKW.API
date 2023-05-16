using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Authorization
{
    public class RemoveUserFromRoleDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string UserName { get; set; }
    }
}
