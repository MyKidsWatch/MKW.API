using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Dto.DTO.OperationDTO
{
    public class OperationDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public bool Finished { get; set; }
        public string StripeId { get; set; }
        public string CheckoutUrl { get; set; }
        public string PaymentStatus { get; set; }
        public OperationDto()
        {

        }
        public OperationDto(Operation operation) : this()
        {
            Id = operation.Id;
            PersonId = operation.PersonId;
            StripeId = operation.StripeId;
        }
    }
}
