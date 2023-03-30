using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Interface.Services.BaseServices;

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
        public async Task<ActionResult<object>> GetMovie([FromRoute] int movieId) => Ok(await _tmdbService.GetMovie(movieId));
    }
}
