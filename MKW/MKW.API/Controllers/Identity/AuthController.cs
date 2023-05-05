using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using MKW.Domain.Dto.IdentityDTO;
using MKW.Domain.Interface.Services.AppServices.Identity;

namespace MKW.API.Controllers.Identity
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("username")]
        public async Task<ActionResult<LoginResponseDTO>> LoginByUserNameAsync([FromBody] LoginRequestByUserNameDTO loginRequestDTO)
        {
            var loginResult = await _service.LoginByUserNameAsync(loginRequestDTO);
            if (loginResult.result.IsSuccess)
            {
                return Ok(loginResult.loginResponse);
            }
            return Unauthorized(loginResult.loginResponse);
        }

        [HttpPost("email")]
        public async Task<ActionResult<LoginResponseDTO>> LoginByEmailAsync([FromBody] LoginRequestByEmailDTO loginRequestDTO)
        {
            var loginResult = await _service.LoginByEmailAsync(loginRequestDTO);
            if (loginResult.result.IsSuccess)
            {
                return Ok(loginResult.loginResponse);
            }
            return Unauthorized(loginResult.loginResponse);
        }
    }
}
