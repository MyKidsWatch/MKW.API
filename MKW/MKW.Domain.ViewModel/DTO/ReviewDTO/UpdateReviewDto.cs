namespace MKW.Domain.Dto.DTO.ReviewDTO
{
    public class UpdateReviewDto
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
    }
}
