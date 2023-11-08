using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using System.Net.Mime;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    public class ReviewController : BaseController
    {
        private readonly IReviewService _reviewService;
        private readonly IAlgorithmService _algorithmService;
        public ReviewController(IReviewService reviewService, IAlgorithmService algorithmService)
        {
            _reviewService = reviewService;
            _algorithmService = algorithmService;
        }

        [HttpGet("id/{id:int}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReviewDetailsDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReviewDetailsDto>>> GetReviews([FromRoute] int id, [FromQuery] string language = "pt-BR")
            => Ok(await _reviewService.GetReviewById(id, language));

        [HttpGet("User/{userId:int}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReviewDetailsDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReviewDetailsDto>>> GetReviewByUserId([FromRoute] int userId, [FromQuery] string language = "pt-BR")
             => Ok(await _reviewService.GetReviewByUserId(userId, language));

        [HttpGet]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReviewDetailsDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReviewDetailsDto>>> GetReviews([FromQuery] int? childId = null, [FromQuery] int page = 1, [FromQuery] int count = 20, [FromQuery] string language = "pt-BR")
            => Ok(await _algorithmService.GetRelevantReviews(page, count, language, childId));

        [HttpGet("Trending")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReviewDetailsDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReviewDetailsDto>>> GetTrendingReviews([FromQuery] int page = 1, [FromQuery] int count = 20, [FromQuery] string language = "pt-BR")
            => Ok(await _algorithmService.GetTrendingReviews(page, count, language));

        [HttpPost]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReviewDetailsDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReviewDetailsDto>>> AddReview([FromBody] CreateReviewDto model)
            => Ok(await _reviewService.CreateReview(model));

        [HttpPut]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReviewDetailsDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReviewDetailsDto>>> UpdateReview([FromBody] UpdateReviewDto model)
            => Ok(await _reviewService.UpdateReview(model));

        [HttpDelete("{id:int}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReviewDetailsDto>>> UpdateReview([FromRoute] int id)
        {
            await _reviewService.DeleteReview(id);
            return NoContent();
        }
    }
}
