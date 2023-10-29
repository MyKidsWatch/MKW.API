using MKW.Data.Context;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.Base;
using MKW.Domain.Utility.Extensions;

namespace MKW.Data.Repository.Base
{
    public class AlgorithmRepository : IAlgorithmRepository
    {
        private readonly MKWContext _context;

        public AlgorithmRepository(MKWContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetRelevantReviews(Person user)
        {
            var reviews =
                _context
                .Person
                .Where(x => x.Id != user.Id)
                .ToList()
                .Where(person => person.Active &&
                       person.Children.Any(x => x.Active) &&
                       person.Reviews.Any(x => x.Active))
                .Select(person => new PersonSimilarity()
                {
                    Person = person,
                    Similarity = GetSimilarities(person,user).Max()

                })
                .OrderByDescending(x => x.Similarity)
                .SelectMany(x => x
                            .Person
                            .Reviews
                            .Where(review => review.Active)
                            .Select(review => new ReviewRelevance()
                            {
                                Review = review,
                                Relevance = x.Similarity * 10
                                          + Math.Log10(review.Comments.ToList().Where(Comment => Comment.Active).Count())
                                          - Math.Log(review.Reports.Count, 5)
                                          + Math.Log10(review.GoldenAwards) * 3
                                          + Math.Log10(review.SilverAwards) * 2
                                          + Math.Log10(review.BronzeAwards)
                                          - Math.Log10(Math.Abs((DateTime.Now - review.CreateDate).Days))
                            })
                            .ToList())
                .OrderByDescending(x => x.Relevance)
                .Select(x => x.Review)
                .ToList();

            return OrderMostRelevant(reviews);
        }

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
    }
}
