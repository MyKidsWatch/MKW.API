using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Authorization;
using MKW.Domain.Interface.Services.AppServices.IdentityService;

namespace MKW.API.Controllers.Identity
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IRoleService _service;
        public AuthorizationController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet("role")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<BaseResponseDTO<object>>> GetAllRoles() => Ok(await _service.GetAllRolesAsync());


        [HttpPost("role/user")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<BaseResponseDTO<object>>> AddUserToRole([FromBody] AddUserToRoleDTO requestDTO)
        {
            var register = await _service.AddUserToRoleAsync(requestDTO.RoleName, requestDTO.UserName);
            return register.IsSuccess ? Ok(register) : BadRequest(register);
        }

        [HttpDelete("role/user")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<BaseResponseDTO<object>>> RemoveUserFromRole([FromBody] RemoveUserFromRoleDTO requestDTO)
        {
            var register = await _service.RemoveUserFromRoleAsync(requestDTO.RoleName, requestDTO.UserName);
            return register.IsSuccess ? Ok(register) : BadRequest(register);
        }
    }
}
