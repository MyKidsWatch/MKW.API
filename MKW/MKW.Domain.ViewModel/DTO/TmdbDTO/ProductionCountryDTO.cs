using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MKW.Domain.Dto.DTO.TmdbDTO
{
    public class ProductionCountryDTO
    {
        [JsonPropertyName("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
