using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Dto.DTO.ReviewDTO
{
    public class ReviewDto
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public double Stars { get; set; }
        public int CommentCount { get; set; }
        public int? UserId { get; set; }
        public int? ContentId { get; set; }
        public string ExternalContentId { get; set; }
        public ReadPersonDTO User { get; set; }

        public ReviewDto(Review review)
        {
            Id = review.Id;
            Title = review.ReviewDetails?.FirstOrDefault()?.Title;
            Text = review.ReviewDetails?.FirstOrDefault()?.Text;
            UserId = review.Person?.Id;
            ContentId = review.Content?.Id;
            ExternalContentId = review.Content?.ExternalId;
            User = new ReadPersonDTO(review.Person);
            CommentCount = review.Comments.Where(x => x.Active).Count();
        }
    }
}
