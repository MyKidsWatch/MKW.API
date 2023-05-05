using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
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
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> GetAllAccounts() => Ok(await _service.GetAllAccountsAsync());

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> GetActiveAccounts() => Ok(await _service.GetActiveAccountsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadUserDTO>> GetAccountByUserId([FromRoute] int id) => Ok(await _service.GetAccountByUserIdAsync(id));

        [HttpGet("username/{userName}")]
        public async Task<ActionResult<ReadUserDTO>> GetAccountByUserName([FromRoute] string userName) => Ok(await _service.GetAccountByUserNameAsync(userName));

        [HttpGet("role/{role}")]
        public async Task<ActionResult<ReadUserDTO>> GetAllAccountsByRole([FromRoute] string role) => Ok(await _service.GetAllAccountsByRoleAsync(role));

        [HttpGet("claim/{claim}")]
        public async Task<ActionResult<ReadUserDTO>> GetAllAccountsByClaim([FromRoute] Claim claim) => Ok(await _service.GetAllAccountsByClaimAsync(claim));

        [HttpPost("register")]
        public async Task<ActionResult<ReadUserDTO>> RegisterAccount([FromBody] CreateUserDTO createUserRequest)
        {
            var register = await _service.RegisterAccountAsync(createUserRequest);
            return register.result.IsSuccess ? 
                CreatedAtAction(nameof(GetAccountByUserId), new { Id = register.user.Id }, register.user) :
                BadRequest(register.result.Reasons);
        }

        [HttpGet("confirmEmail")]
        public async Task<ActionResult> ConfirmAccountEmail([FromQuery] ConfirmAccountEmailDTO confirmEmailRequest)
        {
            var result = await _service.ConfirmAccountEmailAsync(confirmEmailRequest);
            return result.IsSuccess? Ok(result.Successes) : BadRequest(result.Reasons);
        }


        [HttpDelete("username/{userName}")]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> DeleteAccountByUserName([FromRoute] string userName) => Ok(await _service.DeleteAccountByUserNameAsync(userName));

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadUserDTO>> DeleteAccountById([FromRoute] int id) => Ok(await _service.DeleteAccountByIdAsync(id));
    }
}
