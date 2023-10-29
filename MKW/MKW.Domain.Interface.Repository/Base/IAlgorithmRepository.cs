using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Interface.Repository.Base
{
    public interface IAlgorithmRepository
    {
        Task<IEnumerable<Review>> GetRelevantReviews(Person user);
    }
}
