using MKW.Domain.Dto.DTO.PlatformDTO;

namespace MKW.Domain.Dto.DTO.ContentDTO
{
    public class ContentListItemDTO
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public PlatformCategoryDTO Category { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double? AverageRating { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? Tags { get; set; }
    }
}
