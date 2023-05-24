using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using MKW.Domain.Interface.Services.BaseServices;
using System.Net.Mime;
using System.Security.Claims;

namespace MKW.API.Controllers.Identity
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly IEmailService _emailService;

        public AccountController(IAccountService service, IEmailService emailService)
        {
            _service = service;
            _emailService = emailService;
        }

        [HttpGet]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAllAccounts() => Ok(await _service.GetAllAccountsAsync());

        [HttpGet("active")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetActiveAccounts() => Ok(await _service.GetActiveAccountsAsync());

        [HttpGet("id/{id}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAccountByUserId([FromRoute] int id)
        {
            var account = await _service.GetAccountByUserIdAsync(id);
            return account.IsSuccess ? Ok(account) : NotFound(account);
        }

        [HttpGet("username/{userName}")]
        [Authorize(Roles = "admin")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAccountByUserName([FromRoute] string userName)
        {
            var account = await _service.GetAccountByUserNameAsync(userName);
            return account.IsSuccess ? Ok(account) : NotFound(account);
        }

        [HttpGet("role/{role}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAllAccountsByRole([FromRoute] string role)
        {
            var accounts = await _service.GetAllAccountsByRoleAsync(role);
            return accounts.IsSuccess ? Ok(accounts) : BadRequest(accounts);
        }

        [HttpGet("claim/{claim}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAllAccountsByClaim([FromRoute] Claim claim)
        {
            var accounts = await _service.GetAllAccountsByClaimAsync(claim);
            return accounts.IsSuccess ? Ok(accounts) : BadRequest(accounts);
        }

        [HttpPost("register/checkEmail")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<CheckEmailDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<CheckEmailDTO>>> CheckEmail([FromBody] RequestCheckEmailDTO request) => Ok(await _service.CheckEmailAsync(request.Email));

        [HttpPost("register/checkUsername")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<CheckUserNameDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<CheckUserNameDTO>>> CheckUserName([FromBody] RequestCheckUserNameDTO request) => Ok(await _service.CheckUserNameAsync(request.UserName));

        [HttpPost("register")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> RegisterAccount([FromBody] CreateUserDTO createUserRequest)
        {
            var register = await _service.RegisterAccountAsync(createUserRequest);
            return register.IsSuccess ? CreatedAtAction(nameof(GetAccountByUserId), new { Id = register.Content[0].Id }, register) : BadRequest(register);
        }

        [HttpPost("password/keycode")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ResponseGenerateKeycodeDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ResponseGenerateKeycodeDTO>>> RequestPasswordKeycode([FromBody] RequestKeycodeDTO keycodeRequest)
        {
            var result = await _service.RequestPasswordKeycodeAsync(keycodeRequest);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("email/keycode")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> RequestEmailKeycode([FromBody] RequestKeycodeDTO keycodeRequest)
        {
            var result = await _service.RequestEmailKeycodeAsync(keycodeRequest);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPatch("email/confirmEmail")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> ConfirmAccountEmail([FromBody] ConfirmAccountEmailDTO confirmEmailRequest)
        {
            var result = await _service.ConfirmAccountEmailAsync(confirmEmailRequest);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPatch("password/reset")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<ReadUserDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> RecoveryPassword([FromBody] ResetPasswordDTO resetRequest)
        {
            var result = await _service.ResetPasswordAsync(resetRequest);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("username/{userName}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<object>>> DeleteAccountByUserName([FromRoute] string userName) => Ok(await _service.DeleteAccountByUserNameAsync(userName));

        [HttpDelete("{id}")]
        [Authorize]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponseDTO<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(BaseResponseDTO<object>))]
        public async Task<ActionResult<BaseResponseDTO<object>>> DeleteAccountById([FromRoute] int id) => Ok(await _service.DeleteAccountByIdAsync(id));
    }
}
