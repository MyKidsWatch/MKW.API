using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.Base;
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
        public async Task<ActionResult<BaseResponseDTO<TokenDTO>>> LoginByUserName([FromBody] LoginRequestByUserNameDTO loginRequestDTO)
        {
            var loginResult = await _service.LoginByUserNameAsync(loginRequestDTO);
            return loginResult.IsSuccess? Ok(loginResult) : Unauthorized(loginResult);
        }

        [HttpPost("email")]
        public async Task<ActionResult<BaseResponseDTO<TokenDTO>>> LoginByEmail([FromBody] LoginRequestByEmailDTO loginRequestDTO)
        {
            var loginResult = await _service.LoginByEmailAsync(loginRequestDTO);
            return loginResult.IsSuccess ? Ok(loginResult) : Unauthorized(loginResult);
        }

        
        [HttpPost("logout")]
        public async Task<ActionResult<BaseResponseDTO<Object>>> Logout()
        {
            var logoutResult = await _service.LogoutUserAsync();
               return logoutResult.IsSuccess ? Ok(logoutResult) : Unauthorized(logoutResult);
        }
        
    }
}
