using MKW.Domain.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.Identity
{
    public class DeleteUserDTO 
    {
        [Required(ErrorMessage = "The field {0} is required")]
        public int Id { get; set; }

        [MaxLength(12, ErrorMessage = "Max length 12")]
        [MinLength(3, ErrorMessage = "min length 2")]
        public string? UserName { get; set; }

        [EmailAddress(ErrorMessage = "The field {0} is invalid")]
        public string? Email { get; set; }
    }
}
