using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Dto.DTO.IdentityDTO.Authentication;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using System.Net.Mime;

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
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<TokenDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<TokenDTO>>> LoginByUserName([FromBody] LoginRequestByUserNameDTO loginRequestDTO)
        {
            var loginResult = await _service.LoginByUserNameAsync(loginRequestDTO);
            return loginResult.IsSuccess ? Ok(loginResult) : Unauthorized(loginResult);
        }

        [HttpPost("email")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<TokenDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<TokenDTO>>> LoginByEmail([FromBody] LoginRequestByEmailDTO loginRequestDTO)
        {
            var loginResult = await _service.LoginByEmailAsync(loginRequestDTO);
            return loginResult.IsSuccess ? Ok(loginResult) : Unauthorized(loginResult);
        }

        [HttpPost("refresh")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<TokenDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<TokenDTO>>> RefreshLogin()
        {
            var refreshResult = await _service.RefreshLoginAsync(HttpContext);
            return refreshResult.IsSuccess ? Ok(refreshResult) : Unauthorized(refreshResult);
        }
    }
}
