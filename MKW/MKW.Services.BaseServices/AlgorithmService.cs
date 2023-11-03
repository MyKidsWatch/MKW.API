using Microsoft.AspNetCore.Http;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Dto.DTO.TmdbDTO;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.Base;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Domain.Utility.Exceptions;
using MKW.Domain.Utility.Extensions;

namespace MKW.Services.BaseServices
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITmdbService _tmdbService;
        private readonly IReviewService _reviewService;
        private readonly IPersonService _personService;
        private readonly IAlgorithmRepository _algorithmRepository;

        public AlgorithmService(
            IPersonRepository personRepository,
            IHttpContextAccessor httpContextAccessor,
            ITmdbService tmdbService,
            IReviewService reviewService,
            IPersonService personService,
            IAlgorithmRepository algorithmRepository)
        {
            _personRepository = personRepository;
            _httpContextAccessor = httpContextAccessor;
            _tmdbService = tmdbService;
            _reviewService = reviewService;
            _personService = personService;
            _algorithmRepository = algorithmRepository;
        }

        public async Task<BaseResponseDTO<ReviewDetailsDto>> GetRelevantReviews(int page, int count, string language)
        {
            var responseDTO = new BaseResponseDTO<ReviewDetailsDto>();
            var user = await _personService.GetUser();
            if (!user.Children.Where(child => child.Active).Any()) return responseDTO.AddContent(new List<ReviewDetailsDto>());

            var reviews = (await _algorithmRepository.GetRelevantReviews(user, page, count)).Select(x => _reviewService.GetReviewDetails(x, language).Result);
            return reviews == null ? throw new NotFoundException("No reviews were found.") : responseDTO.AddContent(reviews);
        }

        public async Task<BaseResponseDTO<MovieDTO>> GetRelevantMovies(int page, int count, string language)
        {
            var responseDTO = new BaseResponseDTO<MovieDTO>();
            var user = await _personService.GetUser();


            if (!user.Children.Where(child => child.Active).Any()) return responseDTO.AddContent(new List<MovieDTO>());

            var reviews = (await _algorithmRepository.GetRelevantReviews(user, page, count)).Select(x => new ReviewDto(x)) ?? throw new NotFoundException("No reviews were found.");

            var movies = reviews.Select(x => _tmdbService.GetMovie(Int32.Parse(x.ExternalContentId), language).Result);

            return responseDTO.AddContent(movies);
        }

        public async Task<BaseResponseDTO<ReviewDto>> GetRecommended(int page, int count)
        {
            var user = await _personService.GetUser();

            var reviews = (await GetRelevantReviews(user, page, count)).DistinctBy(x => x.Content.ExternalId).Select(x => new ReviewDto(x));
            return reviews == null
                ? throw new NotFoundException("No reviews were found.")
                : new BaseResponseDTO<ReviewDto>().AddContent(reviews);
        }

        public async Task<List<Review>> GetRelevantReviews(Person user, int page, int count)
        {
            List<Person> similarUsers = await GetSimilarUsers(user!);
            List<Review> reviews = GetReviews(similarUsers);

            return reviews.Skip((page - 1) * count).Take(count).ToList();
        }

        public async Task<List<Content>?> GetRecomendations(List<Review> reviews)
        {
            var recommendedMovies = reviews?.Select(x => x.Content).DistinctBy(x => x.Id).ToList();

            return recommendedMovies;
        }

        private async Task<List<Person>> GetSimilarUsers(Person user)
        {
            var similarUsers = new List<Person>();

            var users = await _personRepository.GetActive();

            similarUsers = users?.Where(x => x.Children.Any(y => y.Active) && x.Reviews.Any()).OrderByDescending(x => GetChildrenSimilarity(user, x)).ToList();

            return similarUsers!;
        }

        private double GetChildrenSimilarity(Person user, Person reviewer)
        {
            var minSimilarities = user.Children.Where(x => x.Active).Select(x => GetMinSimilarity(x, reviewer.Children.Where(x => x.Active).ToList())).ToList();
            if (minSimilarities == null) return 1;
            return minSimilarities.Sum() / minSimilarities.Count;
        }

        private double GetMinSimilarity(PersonChild child, List<PersonChild> children)
        {
            return children.Select(x => GetChildSimilarity(child, x)).Min();
        }

        private double GetChildSimilarity(PersonChild child, PersonChild reviewerChild)
        {
            double genderValue = child.GenderId == reviewerChild.GenderId ? 0 : 1;
            double ageValue = Math.Abs(child.AgeRange.GetMeanAge() - reviewerChild.AgeRange.GetMeanAge());

            return GetSimilarity(genderValue, ageValue);
        }

        private double GetSimilarity(params double[] parameters)
        {
            return 1 / (1 + parameters.Sum());
        }

        private List<Review> GetReviews(List<Person> reviewers)
        {
            var reviews = reviewers.SelectMany(x => x.Reviews).ToList();

            return OrderMostRelevant(reviews);
        }

        private List<Review> OrderMostRelevant(List<Review> reviews)
        {
            return reviews
                .Take(150)
                .OrderBy(x => (int)(reviews.IndexOf(x) / 5))
                .ThenByDescending(x => reviews.Count(y => y.ContentId == x.ContentId))
                .DistinctBy(x => x.ContentId)
                .GroupBy(x => reviews.IndexOf(x) / 5)
                .SelectMany(x => x.ToList().Shuffle())
                .Take(100)
                .ToList();
        }
    }
}