using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IAlgorithmService
    {
        Task<BaseResponseDTO<ReviewDto>> GetRecommended(int page, int count);
        Task<List<Review>> GetRelevantReviews(Person user, int page, int count);
        Task<List<Content>?> GetRecomendations(List<Review> reviews);
        Task<BaseResponseDTO<object>> GetRelevantMovies(int page, int count, string language);
    }
}