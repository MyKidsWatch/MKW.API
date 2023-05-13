using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MKW.Domain.Dto.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Interface.Services.AppServices.Identity;
using MKW.Domain.Interface.Services.BaseServices;
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
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAllAccounts() 
            => Ok(await _service.GetAllAccountsAsync());

        [HttpGet("active")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetActiveAccounts() 
            => Ok(await _service.GetActiveAccountsAsync());

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAccountByUserId([FromRoute] int id) 
            => Ok(await _service.GetAccountByUserIdAsync(id));

        [HttpGet("username/{userName}")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAccountByUserName([FromRoute] string userName) 
            => Ok(await _service.GetAccountByUserNameAsync(userName));

        [HttpGet("role/{role}")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAllAccountsByRole([FromRoute] string role) 
            => Ok(await _service.GetAllAccountsByRoleAsync(role));

        [HttpGet("claim/{claim}")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> GetAllAccountsByClaim([FromRoute] Claim claim) 
            => Ok(await _service.GetAllAccountsByClaimAsync(claim));

        [HttpPost("register")]
        public async Task<ActionResult<BaseResponseDTO<ReadUserDTO>>> RegisterAccount([FromBody] CreateUserDTO createUserRequest)
        {
            var register = await _service.RegisterAccountAsync(createUserRequest);
            return register.IsSuccess ? CreatedAtAction(nameof(GetAccountByUserId), new { Id = register.Content.Id } , register) : BadRequest(register);
        }

        [HttpPost("password/keycode")]
        public async Task<ActionResult<BaseResponseDTO<object>>> RequestPasswordKeycode([FromBody] RequestPasswordKeycodeDTO keycodeRequest)
        {
            var result = await _service.RequestPasswordKeycodeAsync(keycodeRequest);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPatch("confirmEmail")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<object>>> ConfirmAccountEmail([FromBody] ConfirmAccountEmailDTO confirmEmailRequest)
        {
            var result = await _service.ConfirmAccountEmailAsync(confirmEmailRequest);
            return result.IsSuccess? Ok(result) : BadRequest(result);
        } 
        
        [HttpPatch("password/reset")]
        public async Task<ActionResult<BaseResponseDTO<object>>> RecoveryPassword([FromBody] ResetPasswordDTO resetRequest)
        {
            var result = await _service.ResetPasswordAsync(resetRequest);
            return result.IsSuccess? Ok(result) : BadRequest(result);
        }

        [HttpDelete("username/{userName}")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<object>>> DeleteAccountByUserName([FromRoute] string userName) 
            => Ok(await _service.DeleteAccountByUserNameAsync(userName));

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponseDTO<object>>> DeleteAccountById([FromRoute] int id) 
            => Ok(await _service.DeleteAccountByIdAsync(id));
    }
}
