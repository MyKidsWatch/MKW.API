using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Dto.Base;
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
        Task<BaseResponseDTO<object>> GetRolesAsync();
        Task<BaseResponseDTO<object>> AddRoleAsync(string role);
        Task<BaseResponseDTO<object>> AddUserToRoleAsync(string roleName, ApplicationUser user);
        Task<BaseResponseDTO<object>> DeleteRoleAsync(string roleName);
        Task<BaseResponseDTO<object>> UpdateRoleAsync(string oldRoleName, string newRoleName);
        Task<BaseResponseDTO<object>> DeleteUserFromRoleAsync(string roleName, ApplicationUser user);
    }
}
