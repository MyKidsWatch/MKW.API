using Microsoft.Extensions.Configuration;
using MKW.Domain.Interface.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
