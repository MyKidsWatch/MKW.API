using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IAlgorithmService
    {
        Task<List<Review>> GetRelevantReviews(int id, int page, int count);
        Task<List<Content>?> GetRecomendations(List<Review> reviews);
    }
}