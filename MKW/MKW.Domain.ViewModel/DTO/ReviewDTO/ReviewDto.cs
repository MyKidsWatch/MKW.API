using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Dto.DTO.ReviewDTO
{
    public class ReviewDto
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ContentId { get; set; }
        public string ExternalContentId { get; set; }

        public ReviewDto(Review review)
        {
            Id = review.UUID;
            Title = review.ReviewDetails?.FirstOrDefault()?.Title;
            Title = review.ReviewDetails?.FirstOrDefault()?.Text;
            UserId = review.Person?.UUID;
            ContentId = review.Content?.UUID;
            ExternalContentId = review.Content?.ExternalId;
        }
    }
}
