using Microsoft.AspNetCore.Mvc;
using MKW.API.Controllers.Base;
using MKW.Domain.Interface.Services.BaseServices;

namespace MKW.API.Controllers
{
    [Route("v1/[controller]")]
    public class AlgorithmController : BaseController
    {
        private readonly IAlgorithmService _algorithmService;
        public AlgorithmController(IAlgorithmService algorithmService)
        {
            _algorithmService = algorithmService;
        }

        [HttpGet]
        public async Task<IActionResult> AlgorithmTest() => Ok(await _algorithmService.Bla());
    }
}
