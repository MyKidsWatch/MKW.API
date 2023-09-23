using Microsoft.Extensions.Configuration;
using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Dto.DTO.TmdbDTO;
using MKW.Domain.Interface.Services.Plugins;
using System.Net.Http.Json;

namespace MKW.Services.Plugin.ContentSources
{
    public class TMDbSource : IExternalSource
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public TMDbSource(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["API:TMDB:key"]!;
            _baseUrl = configuration["API:TMDB:url"]!;
        }

        public async Task<ContentDetailsDTO> GetById(string movieId, string language = "pt-br")
        {
            var movie = (await _client.GetFromJsonAsync<MovieDTO>($"{_baseUrl}/movie/{movieId}?api_key={_apiKey}&language={language}&include_adult=false"))!;
            return new ContentDetailsDTO(movie);
        }

        public async Task<List<ContentListItemDTO>> GetByName(string name, string language = "pt-br")
        {
            var movies = (await _client.GetFromJsonAsync<SearchDTO>($"{_baseUrl}/search/movie?query={name}&language={language}&api_key={_apiKey}&include_adult=false"))!;
            return movies.Results.Select(x => new ContentListItemDTO(x)).ToList();
        }
    }
}
