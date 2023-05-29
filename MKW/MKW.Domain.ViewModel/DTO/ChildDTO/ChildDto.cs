using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Dto.DTO.ChildDTO
{
    public class ChildDto
    {
        public ChildDto()
        {
                
        }
        public int Id { get; set; }
        public int AgeRangeId { get; set; }
        public int GenderId { get; set; }
        public int PersonId { get; set; }

        public ChildDto(PersonChild child) : this()
        {
            Id = child.Id;
            AgeRangeId = child.AgeRangeId;
            GenderId = child.GenderId;
            PersonId = child.PersonId;
        }
    }
}
