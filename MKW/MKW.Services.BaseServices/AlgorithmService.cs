using Microsoft.AspNetCore.Http;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Domain.Utility.Exceptions;
using MKW.Domain.Utility.Extensions;
using System.Security.Claims;

namespace MKW.Services.BaseServices
{
    public class AlgorithmService : IAlgorithmService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITmdbService _tmdbService;

        public AlgorithmService(IPersonRepository personRepository, IHttpContextAccessor httpContextAccessor, ITmdbService tmdbService)
        {
            _personRepository = personRepository;
            _httpContextAccessor = httpContextAccessor;
            _tmdbService = tmdbService;
        }

        public async Task<BaseResponseDTO<object>> GetRelevantMovies(int page, int count, string language)
        {
            var email = _httpContextAccessor.HttpContext?.GetUserEmail();
            var user = await _personRepository.GetByEmail(email);
            if (user == null) throw new NotFoundException("User not found.");

            var reviews = (await GetRelevantReviews(user, page, count)).DistinctBy(x => x.Content.ExternalId).Select(x => new ReviewDto(x));
            if (reviews == null) throw new NotFoundException("No reviews were found.");

            var movies = reviews.Select(x => _tmdbService.GetMovie(Int32.Parse(x.ExternalContentId), language).Result);

            return new BaseResponseDTO<object>().AddContent(movies);
        }

        public async Task<BaseResponseDTO<ReviewDto>> GetRecommended(int page, int count)
        {
            var email = _httpContextAccessor.HttpContext?.GetUserEmail();
            var user = await _personRepository.GetByEmail(email);
            if (user == null) throw new NotFoundException("User not found.");

            var reviews = (await GetRelevantReviews(user, page, count)).DistinctBy(x => x.Content.ExternalId).Select(x => new ReviewDto(x));
            if (reviews == null) throw new NotFoundException("No reviews were found.");

            return new BaseResponseDTO<ReviewDto>().AddContent(reviews);
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

            similarUsers = users?.Where(x => x.Children.Any(y => y.Active)).OrderBy(x => GetChildrenSimilarity(user, x)).ToList();

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

            //adicionar lógica das reviews mais relevantes aqui

            return reviews.Take(500).ToList().Take(100).ToList();
        }
    }
}
