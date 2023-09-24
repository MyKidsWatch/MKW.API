using System.Text.Json.Serialization;

namespace MKW.Domain.Dto.DTO.YoutubeDTO
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

    public class YoutubeIdDto
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; }
    }


}
