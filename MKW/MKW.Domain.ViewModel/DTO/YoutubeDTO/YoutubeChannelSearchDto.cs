using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.YoutubeDTO
{
    public class YoutubeChannelSearchDto
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        [JsonPropertyName("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonPropertyName("regionCode")]
        public string RegionCode { get; set; }

        [JsonPropertyName("pageInfo")]
        public YoutubePageInfoDto PageInfo { get; set; }

        [JsonPropertyName("items")]
        public List<YoutubeChannelListItemDto> Items { get; set; }
    }
}
