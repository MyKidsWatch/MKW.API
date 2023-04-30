using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Services.AppServices;

namespace MKW.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PlatformController : BaseController
    {
        private readonly IPlatformService _platformService;
        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>?>> GetAll() => Ok(await _platformService.Get());
    }
}
