using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.TmdbDTO;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface ITmdbService
    {
        Task<MovieDTO> GetMovie(int movieId, string language = "pt-br");
        Task<BaseResponseDTO<SearchDTO>> GetMovieByName(string name, string language = "pt-br");
    }
}