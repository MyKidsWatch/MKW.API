using Microsoft.Extensions.Configuration;
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

        public async Task<object> GetMovie(int movieId)
        {
            return await _client.GetFromJsonAsync<object>($"{_baseUrl}/movie/{movieId}?api_key={_apiKey}");
        }
    }
}
