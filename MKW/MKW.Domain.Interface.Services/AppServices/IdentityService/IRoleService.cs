using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Authorization;

namespace MKW.Domain.Interface.Services.AppServices.IdentityService
{
    public interface IRoleService
    {
        Task<BaseResponseDTO<ReadRoleDTO>> GetAllRolesAsync();
        Task<BaseResponseDTO<ReadRoleDTO>> GetRolesByNameAsync(string roleName);
        Task<BaseResponseDTO<ReadRoleDTO>> AddUserToRoleAsync(string roleName, string userName);
        Task<BaseResponseDTO<ReadRoleDTO>> RemoveUserFromRoleAsync(string roleName, string userName);
    }
}
