using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Dto.DTO.AwardDTO
{
    public class AwardDetailsDto
    {
        public int AwardId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public AwardDetailsDto()
        {

        }

        public AwardDetailsDto(Award award) : this()
        {
            AwardId = award.Id;
            Name = award.Name;
            Price = award.Price;
        }
    }
}
