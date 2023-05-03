using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.PersonDTO

{
    public class PersonOnCreateUserDTO
    {

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int GenderId { get; set; }
    }
}
