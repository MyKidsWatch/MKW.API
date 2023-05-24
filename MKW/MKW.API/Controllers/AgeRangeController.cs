using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Dto.DTO.AgeRangeDTO;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Interface.Services.AppServices;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AgeRangeController : BaseController
    {
        private readonly IAgeRangeService _ageRangeService;
        public AgeRangeController(IAgeRangeService ageRangeService)
        {
            _ageRangeService = ageRangeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<AgeRangeDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<string>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<string>))]
        public async Task<ActionResult<BaseResponseDTO<AgeRangeDto>>> Get() => Ok(await _ageRangeService.Get());
    }
}
