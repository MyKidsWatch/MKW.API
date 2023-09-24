using System.Text.Json.Serialization;

namespace MKW.Domain.Dto.DTO.YoutubeDTO
{
    public class YoutubeChannelListItemDto
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("snippet")]
        public YoutubeSnippetDto Snippet { get; set; }
    }
}
