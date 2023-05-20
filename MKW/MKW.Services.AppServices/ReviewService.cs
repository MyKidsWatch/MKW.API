using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices.Base;

namespace MKW.Services.AppServices
{
    public class ReviewService : BaseService<Review>, IReviewService
    {
        public ReviewService(IReviewRepository reviewRepository) : base(reviewRepository)
        {
        }
    }
}
