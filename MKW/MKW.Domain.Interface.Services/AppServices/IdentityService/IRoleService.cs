using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.Base;
using MKW.Domain.Dto.DTO.IdentityDTO.Authorization;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
