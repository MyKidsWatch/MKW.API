using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Interface.Repository.Base
{
    public interface IAlgorithmRepository
    {
        Task<IEnumerable<Review>> GetRelevantReviews(Person user, int page = 1, int pageSize = 10, int? childId = null);
        Task<IEnumerable<Review>> GetTrendingReviews(int page = 1, int pageSize = 10);
    }
}
