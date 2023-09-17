using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Dto.DTO.AwardDTO
{
    public class GivenAwardDto
    {
        public int ReviewerReceived { get; set; }
        public ReadPersonDTO Person { get; set; }
        public ReviewDetailsDto Review { get; set; }
        public AwardDetailsDto Award { get; set; }

        public GivenAwardDto()
        {

        }

        public GivenAwardDto(AwardPerson givenAward) : this()
        {
            ReviewerReceived = givenAward.Award.Value;
            Person = new ReadPersonDTO(givenAward.Person);
            Review = new ReviewDetailsDto(givenAward.Review);
            Award = new AwardDetailsDto(givenAward.Award);
        }
    }
}
