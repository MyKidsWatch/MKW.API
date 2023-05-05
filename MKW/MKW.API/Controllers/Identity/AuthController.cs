using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
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
        public async Task<ActionResult<LoginResponseDTO>> LoginByUserName([FromBody] LoginRequestByUserNameDTO loginRequestDTO)
        {
            var loginResult = await _service.LoginByUserNameAsync(loginRequestDTO);
            return loginResult.result.IsSuccess? Ok(loginResult.loginResponse): Unauthorized(loginResult.loginResponse);
        }

        [HttpPost("email")]
        public async Task<ActionResult<LoginResponseDTO>> LoginByEmail([FromBody] LoginRequestByEmailDTO loginRequestDTO)
        {
            var loginResult = await _service.LoginByEmailAsync(loginRequestDTO);
            return loginResult.result.IsSuccess ? Ok(loginResult.loginResponse) : Unauthorized(loginResult.loginResponse);
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout() => _service.LogoutUserAsync().IsCompletedSuccessfully ? Ok() : Unauthorized();
        
    }
}
