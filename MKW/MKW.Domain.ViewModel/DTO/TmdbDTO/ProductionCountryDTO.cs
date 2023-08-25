using Newtonsoft.Json;

namespace MKW.Domain.Dto.DTO.TmdbDTO
{
    public class ProductionCountryDTO
    {
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
