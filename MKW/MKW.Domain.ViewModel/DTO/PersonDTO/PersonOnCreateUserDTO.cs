using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.PersonDTO

{
    public class PersonOnCreateUserDTO
    {

        [Required(ErrorMessage = "The field {0} is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int GenderId { get; set; }
    }
}
