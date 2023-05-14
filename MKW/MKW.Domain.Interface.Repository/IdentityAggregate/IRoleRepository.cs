using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IRoleRepository
    {
        Task<IEnumerable<IdentityRole<int>>> GetRolesAsync();        
        Task<IdentityResult> AddRoleAsync(string role);
        Task<IdentityResult> AddUserToRoleAsync(string roleName, ApplicationUser user);
        Task<IdentityResult> DeleteRoleAsync(string roleName);
        Task<IdentityResult> UpdateRoleAsync(string oldRoleName, string newRoleName);
        Task<IdentityResult> DeleteUserFromRoleAsync(string roleName, ApplicationUser user);
    }
}
