using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using MKW.Domain.Interface.Services.AppServices.Identity;
using System.Security.Claims;

namespace MKW.API.Controllers.Identity
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthenticationController(IAuthService service)
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

        [HttpPost("refresh")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<TokenDTO>>> RefreshLogin()
        {
            var refreshResult = await _service.RefreshLoginAsync(HttpContext);
            return refreshResult.IsSuccess ? Ok(refreshResult) : Unauthorized(refreshResult);
        }
    }
}
