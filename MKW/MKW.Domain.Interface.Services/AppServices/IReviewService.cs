using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IReviewService
    {
        Task<BaseResponseDTO<ReviewDetailsDto>> GetReviewById(int id, string? language = "pt-br");
        Task<BaseResponseDTO<ReviewDetailsDto>> CreateReview(CreateReviewDto model);
        Task<ReviewDetailsDto> GetReviewDetails(Review review, string? language = "pt-br");
    }
}