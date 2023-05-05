using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.IdentityDTO;
using MKW.Domain.Interface.Services.AppServices.Identity;
using System.Security.Claims;

namespace MKW.API.Controllers.Identity
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> GetAllAccounts() => Ok(await _service.GetAllAccounts());

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> GetActiveAccounts() => Ok(await _service.GetActiveAccounts());

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadUserDTO>> GetAccountByUserId([FromRoute] int id) => Ok(await _service.GetAccountByUserId(id));

        [HttpGet("username/{userName}")]
        public async Task<ActionResult<ReadUserDTO>> GetAccountByUserName([FromRoute] string userName) => Ok(await _service.GetAccountByUserName(userName));

        [HttpGet("role/{role}")]
        public async Task<ActionResult<ReadUserDTO>> GetAllAccountsByRole([FromRoute] string role) => Ok(await _service.GetAllAccountsByRole(role));

        [HttpGet("claim/{claim}")]
        public async Task<ActionResult<ReadUserDTO>> GetAllAccountsByClaim([FromRoute] Claim claim) => Ok(await _service.GetAllAccountsByClaim(claim));

        [HttpPost]
        public async Task<ActionResult<ReadUserDTO>> RegisterAccount([FromBody] CreateUserDTO createUserDTO)
        {
            var register = await _service.RegisterAccount(createUserDTO);
            if (register.result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetAccountByUserId), new { Id = register.user.Id }, register.user);
            }
            return StatusCode(400, register.result.Reasons);
        }


        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<ReadUserDTO>> UpdateAccount([FromBody] UpdateUserDTO createUserDTO)
        //{
        //    Console.WriteLine(createUserDTO.ToString());
        //    var register = await _service.RegisterAccount(createUserDTO);
        //    return CreatedAtAction(nameof(GetAccountByUserId), new { Id = register.user.Id }, register.user);
        //}


        [HttpDelete("{userName}")]
        public async Task<ActionResult<IEnumerable<ReadUserDTO>>> DeleteAccountByUserName([FromRoute] string userName) => Ok(await _service.DeleteAccountByUserName(userName));

        [HttpDelete("{id}")]
        public async Task<ActionResult<ReadUserDTO>> DeleteAccountById([FromRoute] int id) => Ok(await _service.DeleteAccountById(id));
    }
}
