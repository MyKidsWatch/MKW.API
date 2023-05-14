using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Data.Repository.IdentityAggregate
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RoleRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddRoleAsync(string role)
        {
            return await _roleManager.CreateAsync(new IdentityRole<int> { Name = role});
        }

        public async  Task<IdentityResult> AddUserToRoleAsync(string roleName, ApplicationUser user)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if(role is not null)
            {
                return await _userManager.AddToRoleAsync(user, role.Name);
            }
            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role is not null)
            {
                return await _roleManager.DeleteAsync(role);
            }
            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteUserFromRoleAsync(string roleName, ApplicationUser user)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role is not null)
            {
                return await _userManager.RemoveFromRoleAsync(user, role.Name);
            }
            return IdentityResult.Failed();
        }

        public async Task<IEnumerable<IdentityRole<int>>> GetRolesAsync()
        {
            return _roleManager.Roles;
        }

        public async Task<IdentityResult> UpdateRoleAsync(string oldRoleName, string newRoleName)
        {
            var role = await _roleManager.FindByNameAsync(oldRoleName);
            if (role is not null)
            {
                return await _roleManager.SetRoleNameAsync(role, newRoleName);
            }
            return IdentityResult.Failed();
        }
    }
}
