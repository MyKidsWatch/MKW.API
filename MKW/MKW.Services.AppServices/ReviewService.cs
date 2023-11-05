using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Services.AppServices
{
    public class ReviewService : IReviewService
    {
        private readonly IContentService _contentService;
        private readonly IReviewDetailsRepository _reviewDetailsRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly ITmdbService _tmdbService;
        private readonly IPersonService _personService;

        public ReviewService
            (
            IContentService contentService,
            IReviewDetailsRepository reviewDetailsRepository,
            IReviewRepository reviewRepository,
            ITmdbService tmdbService,
            IPersonService personService
            )
        {
            _contentService = contentService;
            _reviewDetailsRepository = reviewDetailsRepository;
            _reviewRepository = reviewRepository;
            _tmdbService = tmdbService;
            _personService = personService;
        }

        public async Task<BaseResponseDTO<ReviewDetailsDto>> GetReviewById(int id, string? language = "pt-br")
        {
            var responseDTO = new BaseResponseDTO<ReviewDetailsDto>();
            var review = await _reviewRepository.GetById(id) ?? throw new NotFoundException("Review not found.");
            if (!review.Active) throw new NotFoundException("Review not found.");

            return responseDTO.AddContent(await GetReviewDetails(review, language));
        }

        public async Task<BaseResponseDTO<ReviewDetailsDto>> GetReviewByUserId(int userId, string? language = "pt-br")
        {
            var responseDTO = new BaseResponseDTO<ReviewDetailsDto>();
            var review = await _reviewRepository.GetByUserId(userId) ?? throw new NotFoundException("Review not found.");
            if (!review.Any()) throw new NotFoundException("Review not found.");

            return responseDTO.AddContent(review.Select(x => GetReviewDetails(x, language).Result));
        }

        public async Task<BaseResponseDTO<ReviewDetailsDto>> CreateReview(CreateReviewDto model)
        {
            var responseDTO = new BaseResponseDTO<ReviewDetailsDto>();
            var content = await GetContent(model) ?? throw new NotFoundException("Content not found.");
            var person = await _personService.GetUser();
            if (model.Stars > 5) throw new BadRequestException("Maximum Star Number is 5");
            if (model.Stars < 0) throw new BadRequestException("Minimum Star Number is 0");
            if (String.IsNullOrEmpty(model.Title)) throw new BadRequestException("Title required");
            if (String.IsNullOrEmpty(model.Text)) throw new BadRequestException("Text required");

            var review = new Review()
            {
                ContentId = content.Id,
                PersonId = person.Id
            };

            review = await _reviewRepository.Add(review);

            var reviewDetails = new ReviewDetails()
            {
                ReviewId = review.Id,
                Title = model.Title,
                Text = model.Text,
                Stars = model.Stars
            };

            await _reviewDetailsRepository.Add(reviewDetails);

            return responseDTO.AddContent(await GetReviewDetails(review));
        }

        public async Task<BaseResponseDTO<ReviewDetailsDto>> UpdateReview(UpdateReviewDto model)
        {
            var responseDTO = new BaseResponseDTO<ReviewDetailsDto>();
            var review = await _reviewRepository.GetById(model.ReviewId) ?? throw new NotFoundException("Review not found.");
            var person = await _personService.GetUser();
            if (model.Stars > 5) throw new BadRequestException("Maximum Star Number is 5");
            if (model.Stars < 0) throw new BadRequestException("Minimum Star Number is 0");
            if (String.IsNullOrEmpty(model.Title)) throw new BadRequestException("Title required");
            if (String.IsNullOrEmpty(model.Text)) throw new BadRequestException("Text required");

            if (person.Id != review.PersonId) throw new BadRequestException("User isn't reviewer");

            if (review.ReviewDetails.Count > 1) throw new BadRequestException("Review already updated");

            var reviewDetails = new ReviewDetails()
            {
                ReviewId = review.Id,
                Title = model.Title,
                Text = model.Text,
                Stars = model.Stars
            };

            await _reviewDetailsRepository.Add(reviewDetails);

            return responseDTO.AddContent(await GetReviewDetails(review));
        }

        public async Task DeleteReview(int reviewId)
        {
            var review = await _reviewRepository.GetById(reviewId) ?? throw new NotFoundException("Review not found.");
            var person = await _personService.GetUser();

            if (person.Id != review.PersonId) throw new BadRequestException("User isn't reviewer");

            await _reviewRepository.Delete(review);
        }

        public async Task<ReviewDetailsDto> GetReviewDetails(Review review, string? language = "pt-br")
        {
            var detailedReview = new ReviewDetailsDto(review);

            var content = await _contentService.GetExternalContent(review.Content.ExternalId, review.Content.PlatformCategory.PlatformId);

            detailedReview.Content = new ReadContentDTO()
            {
                Id = review.ContentId,
                ExternalId = review.Content.ExternalId,
                Name = content.Name,
                ImageUrl = content.ImageUrl ?? "",
                PlatformCategory = review.Content.PlatformCategoryId,
                PlatformId = review.Content.PlatformCategory.PlatformId
            };

            return detailedReview;
        }

        private async Task<Content> GetContent(CreateReviewDto model)
            => model.ContentId != null ?
                await _contentService.GetContentById(model.ContentId ?? 0) :
                await _contentService.GetContentByExternalId(model.ExternalContentId ?? "", model.PlatformId ?? 1);
    }
}