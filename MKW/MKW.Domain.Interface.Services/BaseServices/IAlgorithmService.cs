using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Dto.DTO.TmdbDTO;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IAlgorithmService
    {
        Task<BaseResponseDTO<ReviewDto>> GetRecommended(int page, int count);
        //Task<BaseResponseDTO<ReviewDetailsDto>> GetRelevantReviews(int page, int count, string language);
        Task<List<Review>> GetRelevantReviews(Person user, int page, int count);
        Task<List<Content>?> GetRecomendations(List<Review> reviews);
        Task<BaseResponseDTO<MovieDTO>> GetRelevantMovies(int page, int count, string language);
    }
}