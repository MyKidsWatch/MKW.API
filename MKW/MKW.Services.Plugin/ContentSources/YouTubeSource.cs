using Microsoft.Extensions.Configuration;
using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Dto.DTO.YoutubeDTO;
using MKW.Domain.Interface.Services.Plugins;
using MKW.Domain.Utility.Enums;
using MKW.Domain.Utility.Exceptions;
using System.Net.Http.Json;
using System.Xml.Linq;

namespace MKW.Services.Plugin.ContentSources
{
    public class YouTubeSource : IExternalSource
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public YouTubeSource(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["API:YouTube:key"]!;
            _baseUrl = configuration["API:YouTube:url"]!;
        }

        public async Task<ContentDetailsDTO> GetById(string contentId, string language = "pt-br")
        {
            try
            {
                var get = await _client.GetAsync($"{_baseUrl}/channels?key={_apiKey}&id={contentId}&part=snippet");
                if (!get.IsSuccessStatusCode) return new ContentDetailsDTO();

                var search = await get.Content.ReadFromJsonAsync<YoutubeChannelSearchDto>();

                return search?.Items?.Select(x => new ContentDetailsDTO(x)
                {
                    PlatformId = (int)PlatformEnum.Youtube
                }).FirstOrDefault() ?? throw new NotFoundException("Channel not found.");
            }
            catch
            {
                return new ContentDetailsDTO();
            }
        }

        public async Task<List<ContentListItemDTO>> GetByName(string name, string language = "pt-br")
        {
            try
            {
                var get = await _client.GetAsync($"{_baseUrl}/search?key={_apiKey}&q={name}&part=snippet&type=channel");
                if (!get.IsSuccessStatusCode) return new List<ContentListItemDTO>();

                var search = await get.Content.ReadFromJsonAsync<YoutubeSearchDto>();

                return search?.Items?.Select(x => new ContentListItemDTO(x)
                {
                    PlatformId = (int)PlatformEnum.Youtube
                }).ToList() ?? throw new NotFoundException("Channel not found.");
            }
            catch
            {
                return new List<ContentListItemDTO>();
            }
        }
    }
}
