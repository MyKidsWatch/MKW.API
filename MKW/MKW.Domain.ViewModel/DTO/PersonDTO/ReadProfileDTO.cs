using MKW.Domain.Dto.DTO.AwardDTO;
using MKW.Domain.Dto.DTO.ChildDTO;

namespace MKW.Domain.Dto.DTO.PersonDTO
{
    public class ReadProfileDTO
    {
        public int UserId { get; set; }
        public string? ImageURL { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public ICollection<ChildDto> Childrens { get; set; }
        public ICollection<ReadAwardDTO> Awards { get; set; }
    }
}
