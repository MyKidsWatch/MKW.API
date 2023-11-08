using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Dto.DTO.CommentDTO
{
    public class CommentDetailsDto
    {
        public int Id { get; set; }
        public ReadPersonDTO Person { get; set; }
        public IEnumerable<CommentDetailsDto>? Answers { get; set; }
        public string Text { get; set; }
        public int AnswersQuantity { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Edited { get; set; }

        public CommentDetailsDto()
        {

        }

        public CommentDetailsDto(Comment comment) : this()
        {
            Id = comment.Id;
            Person = new ReadPersonDTO(comment.Person);
            Answers = comment.Answers?.Where(x => x.Active).Select(x => new CommentDetailsDto(x)) ?? new List<CommentDetailsDto>();
            AnswersQuantity = comment.Answers?.Where(x => x.Active).Count() ?? 0;
            CreateDate = comment.CreateDate;
            Edited = comment.CommentDetails.Count > 1;

            var latestVersion = comment.CommentDetails.OrderByDescending(x => x.CreateDate).FirstOrDefault();
            Text = latestVersion?.Text ?? "";
        }
    }
}
