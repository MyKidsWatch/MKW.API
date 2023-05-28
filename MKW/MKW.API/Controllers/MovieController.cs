using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Interface.Services.BaseServices;
using System.Net.Mime;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class MovieController : BaseController
    {
        private readonly ITmdbService _tmdbService;

        public MovieController(ITmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("{movieId:int}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<object>> GetMovie([FromRoute] int movieId) => Ok(await _tmdbService.GetMovie(movieId));

        [HttpGet]
        public async Task<ActionResult<object>> GetMovieByName([FromQuery] string name) => Ok(await _tmdbService.GetMovieByName(name));
    }
}
