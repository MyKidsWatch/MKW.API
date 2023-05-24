using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.GenderDTO;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    public class GenderController : BaseController
    {

        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponseDTO<GenderDto>>> Get() => Ok(_genderService.Get());
    }
}
