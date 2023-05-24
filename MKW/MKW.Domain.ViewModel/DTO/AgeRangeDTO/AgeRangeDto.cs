using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Dto.DTO.AgeRangeDTO
{
    public class AgeRangeDto
    {
        public int Id { get; set; }
        public int InitialAge { get; set; }
        public int FinalAge { get; set; }

        public AgeRangeDto(AgeRange ageRange)
        {
            Id = ageRange.Id;
            InitialAge = ageRange.InitialAge;
            FinalAge = ageRange.FinalAge;
        }
    }
}
