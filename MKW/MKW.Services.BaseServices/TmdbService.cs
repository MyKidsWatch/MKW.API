using Microsoft.Extensions.Configuration;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.TmdbDTO;
using MKW.Domain.Interface.Services.BaseServices;
using Newtonsoft.Json;
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

        public async Task<MovieDTO> GetMovie(int movieId, string language = "pt-br")
        {
            try
            {
                return (await _client.GetFromJsonAsync<MovieDTO>($"{_baseUrl}/movie/{movieId}?api_key={_apiKey}&language={language}&include_adult=false"))!;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<BaseResponseDTO<SearchDTO>> GetMovieByName(string name, string language = "pt-br")
        {
            var movies = (await _client.GetFromJsonAsync<SearchDTO>($"{_baseUrl}/search/movie?query={name}&language={language}&api_key={_apiKey}&include_adult=false"))!;
            return new BaseResponseDTO<SearchDTO>().AddContent(movies);
        }
    }
}
