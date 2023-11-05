using MKW.Domain.Dto.DTO.CommentDTO;
using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Dto.DTO.ReviewDTO
{
    public class ReviewDetailsDto
    {
        public int Id { get; set; }
        public ReadPersonDTO Person { get; set; }
        public ReadContentDTO Content { get; set; }
        public IEnumerable<CommentDetailsDto>? Comments { get; set; }
        public int GoldenAwards { get; set; }
        public int SilverAwards { get; set; }
        public int BronzeAwards { get; set; }
        public int CommentsQuantity { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Edited { get; set; }

        public ReviewDetailsDto()
        {

        }

        public ReviewDetailsDto(Review review) : this()
        {
            Id = review.Id;
            Person = new ReadPersonDTO(review.Person);
            Comments = review.Comments?.Where(x => x.Active && x.IsFirstLevel()).Select(x => new CommentDetailsDto(x)) ?? new List<CommentDetailsDto>();
            CommentsQuantity = review.Comments?.Where(x => x.Active).Count() ?? 0;
            CreateDate = review.CreateDate;
            Edited = review.ReviewDetails.Count > 1;

            var latestVersion = review.ReviewDetails.OrderByDescending(x => x.CreateDate).FirstOrDefault();
            Title = latestVersion?.Title ?? "";
            Text = latestVersion?.Text ?? "";
            Stars = latestVersion?.Stars ?? 0;

            GoldenAwards = review.Awards?.Where(x => x.Award.Name == "Gold").Count() ?? 0;
            SilverAwards = review.Awards?.Where(x => x.Award.Name == "Silver").Count() ?? 0;
            BronzeAwards = review.Awards?.Where(x => x.Award.Name == "Bronze").Count() ?? 0;
        }
    }
}
