using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.CommentDTO;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface ICommentService
    {
        Task<BaseResponseDTO<CommentDetailsDto>> AnswerComment(AnswerCommentDto model);
        Task<BaseResponseDTO<CommentDetailsDto>> CreateComment(CreateCommentDto model);
        Task DeleteComment(int commentId);
        Task<BaseResponseDTO<CommentDetailsDto>> GetCommentById(int id, string? language = "pt-br");
        Task<BaseResponseDTO<CommentDetailsDto>> UpdateComment(UpdateCommentDto model);

        Task<BaseResponseDTO<CommentDetailsDto>> GetCommentByReviewId(int reviewId, string? language = "pt-br");

    }
}