using System.Text.Json.Serialization;

namespace MKW.Domain.Dto.DTO.TmdbDTO
{
    public class GenreDTO
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
