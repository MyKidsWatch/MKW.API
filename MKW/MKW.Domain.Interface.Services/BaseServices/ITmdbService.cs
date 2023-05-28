using MKW.Domain.Dto.DTO.Base;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface ITmdbService
    {
        Task<object> GetMovie(int movieId);
        Task<BaseResponseDTO<object>> GetMovieByName(string name);
    }
}