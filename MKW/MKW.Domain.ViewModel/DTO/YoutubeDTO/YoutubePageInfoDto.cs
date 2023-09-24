using System.Text.Json.Serialization;

namespace MKW.Domain.Dto.DTO.YoutubeDTO
{
    public class YoutubePageInfoDto
    {
        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("resultsPerPage")]
        public int ResultsPerPage { get; set; }
    }


}
