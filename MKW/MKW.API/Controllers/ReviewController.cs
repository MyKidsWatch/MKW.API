using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Services.AppServices;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    public class ReviewController : CrudBaseController<Review>
    {

        public ReviewController(IReviewService reviewService) : base(reviewService)
        {
        }

    }
}
