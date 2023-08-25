using Newtonsoft.Json;

namespace MKW.Domain.Dto.DTO.TmdbDTO
{
    public class GenreDTO
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
