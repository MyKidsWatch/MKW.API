using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.CommentDTO;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Services.AppServices
{
    public class CommentService
    {
        private readonly ICommentDetailsRepository _commentDetailsRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IPersonService _personService;
        private readonly IReviewRepository _reviewRepository;

        public CommentService
            (
            ICommentDetailsRepository commentDetailsRepository,
            ICommentRepository commentRepository,
            IPersonService personService,
            IReviewRepository reviewRepository
            )
        {
            _commentDetailsRepository = commentDetailsRepository;
            _commentRepository = commentRepository;
            _personService = personService;
            _reviewRepository = reviewRepository;
        }

        public async Task<BaseResponseDTO<CommentDetailsDto>> GetCommentById(int id, string? language = "pt-br")
        {
            var responseDTO = new BaseResponseDTO<CommentDetailsDto>();
            var comment = await _commentRepository.GetById(id) ?? throw new NotFoundException("Comment not found.");
            if (!comment.Active) throw new NotFoundException("Comment not found.");

            return responseDTO.AddContent(new CommentDetailsDto(comment));
        }

        public async Task<BaseResponseDTO<CommentDetailsDto>> CreateComment(CreateCommentDto model)
        {
            var responseDTO = new BaseResponseDTO<CommentDetailsDto>();
            var review = await _reviewRepository.GetById(model.ReviewId) ?? throw new NotFoundException("Review not found.");
            var person = await _personService.GetUser();
            if (String.IsNullOrEmpty(model.Text)) throw new BadRequestException("Text required");

            var comment = new Comment()
            {
                ReviewId = review.Id,
                PersonId = person.Id
            };

            comment = await _commentRepository.Add(comment);

            var commentDetails = new CommentDetails()
            {
                CommentId = comment.Id,
                Text = model.Text
            };

            await _commentDetailsRepository.Add(commentDetails);

            return responseDTO.AddContent(new CommentDetailsDto(comment));
        }

        public async Task<BaseResponseDTO<CommentDetailsDto>> UpdateComment(UpdateCommentDto model)
        {
            var responseDTO = new BaseResponseDTO<CommentDetailsDto>();
            var comment = await _commentRepository.GetById(model.CommentId) ?? throw new NotFoundException("Comment not found.");
            var person = await _personService.GetUser();
            if (String.IsNullOrEmpty(model.Text)) throw new BadRequestException("Text required");

            if (person.Id != comment.PersonId) throw new BadRequestException("User isn't commenter");

            if (comment.CommentDetails.Count > 1) throw new BadRequestException("Comment already updated");

            var reviewDetails = new CommentDetails()
            {
                CommentId = comment.Id,
                Text = model.Text,
            };

            await _commentDetailsRepository.Add(reviewDetails);

            return responseDTO.AddContent(new CommentDetailsDto(comment));
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _commentRepository.GetById(commentId) ?? throw new NotFoundException("Comment not found.");
            var person = await _personService.GetUser();

            if (person.Id != comment.PersonId) throw new BadRequestException("User isn't commenter");

            await _commentRepository.Delete(comment);
        }
    }
}
