using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ContentDTO;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Dto.DTO.TmdbDTO;
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
            return responseDTO.AddContent(await GetReviewDetails(review, language));
        }

        public async Task<BaseResponseDTO<ReviewDetailsDto>> CreateReview(CreateReviewDto model)
        {
            var responseDTO = new BaseResponseDTO<ReviewDetailsDto>();
            var content = await GetContent(model) ?? throw new NotFoundException("Content not found.");
            var person = await _personService.GetUser();

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

        public async Task<ReviewDetailsDto> GetReviewDetails(Review review, string? language = "pt-br")
        {
            var detailedReview = new ReviewDetailsDto(review);

            var movie = _tmdbService.GetMovie(Int32.Parse(review.Content.ExternalId), language).Result;

            detailedReview.Content = new ReadContentDTO()
            {
                Id = review.ContentId,
                Name = movie.Title,
                ImageUrl = movie.PosterPath,
                PlatformCategory = review.Content.PlatformCategoryId
            };

            return detailedReview;
        }

        private async Task<Content> GetContent(CreateReviewDto model)
            => model.ContentId != null ?
                await _contentService.GetContentById(model.ContentId ?? 0) :
                await _contentService.GetContentByExternalId(model.ExternalContentId);
    }
}