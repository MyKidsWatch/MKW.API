using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MKW.Data.Context;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.Base;
using MKW.Domain.Utility.Enums;
using MKW.Domain.Utility.Extensions;
using System.Data;

namespace MKW.Data.Repository.Base
{
    public class AlgorithmRepository : IAlgorithmRepository
    {
        private readonly MKWContext _context;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AlgorithmRepository(MKWContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnString"];
        }

        public async Task<IEnumerable<Review>> GetRelevantReviews(Person user, int page = 1, int pageSize = 10, int? childId = null)
        {
            var relevant = new List<FetchReviewDto>();

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();

                relevant =
                    con.Query<FetchReviewDto>(StoredProcedures.Algorithm, new
                    {
                        @PERSON_ID = user.Id,
                        @CHILD_ID = childId,
                        @PAGE = page,
                        @PAGE_SIZE = pageSize,
                    }, commandType: CommandType.StoredProcedure).ToList();

                con.Close();
                con.Dispose();
            }

            return await GetReviews(relevant);
        }

        public async Task<IEnumerable<Review>> GetTrendingReviews(int page = 1, int pageSize = 10)
        {
            var trending = new List<FetchReviewDto>();

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();

                trending =
                    con.Query<FetchReviewDto>(StoredProcedures.Trending, new
                    {
                        @PAGE = page,
                        @PAGE_SIZE = pageSize,
                    }, commandType: CommandType.StoredProcedure).ToList();

                con.Close();
                con.Dispose();
            }

            return await GetReviews(trending);
        }

        public async Task<List<Review>> GetReviews(List<FetchReviewDto> relevant)
        {
            var reviews = await
            _context.Review
            .Include(x => x.Content)
            .ThenInclude(x => x.PlatformCategory)
            .Include(x => x.Person)
            .ThenInclude(x => x.User)
            .Include(x => x.Awards)
            .ThenInclude(x => x.Award)
            .Include(x => x.ReviewDetails)
            .Include(x => x.Comments)
            .ThenInclude(x => x.CommentDetails)
            .Include(x => x.Comments)
            .ThenInclude(x => x.Person)
            .ThenInclude(x => x.User)
            .Include(x => x.Comments)
            .ThenInclude(x => x.Answers)
            .ThenInclude(x => x.Person)
            .ThenInclude(x => x.User)
            .Include(x => x.Comments)
            .ThenInclude(x => x.Answers)
            .ThenInclude(x => x.CommentDetails)
            .Include(x => x.Comments)
            .ThenInclude(x => x.Answers)
            .ThenInclude(x => x.Answers)
            .Where(x => relevant.Select(y => y.ReviewId).Contains(x.Id))
            .AsNoTracking()
            .ToListAsync();

            return reviews;
        }


        #region Deprecated
        private List<Review> OrderMostRelevant(List<Review> reviews)
        {
            return reviews
                .Take(300)
                .OrderBy(x => (int)(reviews.IndexOf(x) / 5))
                .ThenByDescending(x => reviews.Count(y => y.ContentId == x.ContentId))
                .DistinctBy(x => x.ContentId)
                .GroupBy(x => reviews.IndexOf(x) / 5)
                .SelectMany(x => x.ToList().Shuffle())
                .ToList();
        }

        private List<double> GetSimilarities(Person person, Person user)
        {
            return person
                .Children
                .Where(child => child.Active)
                .Select(child => GetMaxSimilarity(child, user.Children.Where(x => x.Active).ToList()))
                .ToList();
        }

        private double GetMaxSimilarity(PersonChild child, IEnumerable<PersonChild> children)
        {
            return children.Select(x => GetChildSimilarity(child, x)).Max();
        }

        private double GetChildSimilarity(PersonChild child, PersonChild reviewerChild)
        {
            double genderValue = child.GenderId == reviewerChild.GenderId ? 0 : 1;
            double ageValue = Math.Abs(child.AgeRange.GetMeanAge() - reviewerChild.AgeRange.GetMeanAge());

            return GetChildrenSimilarity(genderValue, ageValue);
        }

        private double GetChildrenSimilarity(params double[] parameters)
        {
            return 1 - (1 / (1 + parameters.Sum()));
        }
        #endregion
    }
}
