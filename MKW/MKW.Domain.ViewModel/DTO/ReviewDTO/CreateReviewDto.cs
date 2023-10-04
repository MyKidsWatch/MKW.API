namespace MKW.Domain.Dto.DTO.ReviewDTO
{
    public class CreateReviewDto
    {
        public int? ContentId { get; set; }
        public string? ExternalContentId { get; set; }
        public int? PlatformId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
    }
}
