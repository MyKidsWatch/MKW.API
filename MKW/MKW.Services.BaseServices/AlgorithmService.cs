﻿using Microsoft.AspNetCore.Http;
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

        public AlgorithmService(IPersonRepository personRepository, IHttpContextAccessor httpContextAccessor)
        {
            _personRepository = personRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponseDTO<ReviewDto>> GetRecommended(int page, int count)
        {
            var email = _httpContextAccessor.HttpContext?.User?.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
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
            List<Content> recommendedMovies = reviews?.Select(x => x.Content).DistinctBy(x => x.Id).ToList();

            return recommendedMovies;
        }

        private async Task<List<Person>> GetSimilarUsers(Person user)
        {
            var similarUsers = new List<Person>();

            var users = await _personRepository.GetActive();

            similarUsers = users?.OrderBy(x => GetChildrenSimilarity(user, x)).ToList();

            return similarUsers!;
        }

        private double GetChildrenSimilarity(Person user, Person reviewer)
        {
            var minSimilarities = user.Children.SelectAsync(async x => await GetMinSimilarity(x, reviewer.Children.ToList())).Result;

            return minSimilarities.Sum() / minSimilarities.Count();
        }

        private async Task<double> GetMinSimilarity(PersonChild child, List<PersonChild> children)
        {
            return children.SelectAsync(async x => await GetChildSimilarity(child, x)).Result.Min();
        }

        private async Task<double> GetChildSimilarity(PersonChild child, PersonChild reviewerChild)
        {
            double genderValue = child.GenderId == reviewerChild.GenderId ? 0 : 1;
            double ageValue = Math.Abs(child.AgeRange.GetMeanAge() - reviewerChild.AgeRange.GetMeanAge());

            return await GetSimilarity(genderValue, ageValue);
        }

        private async Task<double> GetSimilarity(params double[] parameters)
        {
            return 1 / (1 + parameters.Sum());
        }

        private List<Review> GetReviews(List<Person> reviewers)
        {
            var reviews = reviewers.SelectMany(x => x.Reviews).ToList();

            //adicionar lógica das reviews mais relevantes aqui

            return reviews.Take(500).ToList().Shuffle().Take(100).ToList();
        }
    }
}
