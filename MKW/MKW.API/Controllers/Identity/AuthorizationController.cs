using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Account;
using MKW.Domain.Interface.Services.AppServices.Identity;
using MKW.Domain.Interface.Services.AppServices.IdentityService;

namespace MKW.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IRoleService _service;
        public AuthorizationController(IRoleService service)
        {
            _service = service;
        }

        [HttpPost("role/{name}")]
        public async Task<ActionResult<BaseResponseDTO<object>>> AddRole([FromRoute] string name)
        {
            var register = await _service.AddRoleAsync(name);
            return register.IsSuccess ? /*CreatedAtAction(nameof(GetAccountByUserId), new { Id = register.Content.Id }, register)*/ Ok(register) : BadRequest(register);
        }
    }
}
