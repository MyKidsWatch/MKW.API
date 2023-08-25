using Newtonsoft.Json;

namespace MKW.Domain.Dto.DTO.TmdbDTO
{
    public class SpokenLanguageDTO
    {
        [JsonProperty("english_name")]
        public string EnglishName { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
