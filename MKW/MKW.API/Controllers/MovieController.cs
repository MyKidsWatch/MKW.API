using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.TmdbDTO;
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

        [HttpGet("id/{movieId:int}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<MovieDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<MovieDTO>>> GetMovie([FromRoute] int movieId, [FromQuery] string? language = "pt-BR") => Ok(new BaseResponseDTO<object>().AddContent(await _tmdbService.GetMovie(movieId, language)));

        [HttpGet]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<object>>> GetMovieByName([FromQuery] string name, [FromQuery] string? language = "pt-BR") => Ok(await _tmdbService.GetMovieByName(name, language));
    }
}
