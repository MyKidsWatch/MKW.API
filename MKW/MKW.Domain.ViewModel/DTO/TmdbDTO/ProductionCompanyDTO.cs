using Newtonsoft.Json;

namespace MKW.Domain.Dto.DTO.TmdbDTO
{
    public class ProductionCompanyDTO
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }
    }
}
