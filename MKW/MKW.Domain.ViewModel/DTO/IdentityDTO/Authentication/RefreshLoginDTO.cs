using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Auth
{
    public class RefreshLoginDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }
    }
}
