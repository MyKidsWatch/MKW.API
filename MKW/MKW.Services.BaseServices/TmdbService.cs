using Microsoft.Extensions.Configuration;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Interface.Services.BaseServices;
using System.Net.Http.Json;

namespace MKW.Services.BaseServices
{
    public class TmdbService : ITmdbService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public TmdbService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["API:TMDB:key"]!;
            _baseUrl = configuration["API:TMDB:url"]!;
        }

        public async Task<object> GetMovie(int movieId, string language)
        {
            return (await _client.GetFromJsonAsync<object>($"{_baseUrl}/movie/{movieId}?api_key={_apiKey}&language={language}"))!;

        }

        public async Task<BaseResponseDTO<object>> GetMovieByName(string name, string language)
        {
            var objects = (await _client.GetFromJsonAsync<object>($"{_baseUrl}/search/movie?query={name}&language={language}&api_key={_apiKey}"))!;
            return new BaseResponseDTO<object>().AddContent(objects);
        }
    }
}
