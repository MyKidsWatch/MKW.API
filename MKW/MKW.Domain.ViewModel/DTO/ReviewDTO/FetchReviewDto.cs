namespace MKW.Domain.Dto.DTO.ReviewDTO
{
    public class FetchReviewDto
    {
        public int ReviewId { get; set; }
        public int PersonId { get; set; }
        public float Similarity { get; set; }
        public float CommentsRelevancy { get; set; }
        public float DateRelevancy { get; set; }
        public float ReportsRelevancy { get; set; }
    }
}
