namespace MKW.Domain.Dto.DTO.ContentDTO
{
    public class ReadContentDTO
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int PlatformCategory { get; set; }
        public int? PlatformId { get; set; }
    }
}
