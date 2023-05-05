using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Data.Repository.IdentityAggregate
{
    public class UserRepository : IUserRepository
    {
        private readonly MKWContext _context;
        protected readonly DbSet<ApplicationUser> _dbSet;
        protected readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(MKWContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _dbSet = _context.Set<ApplicationUser>();
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(int id) => await _userManager.FindByIdAsync(id.ToString());
        public async Task<ApplicationUser?> GetUserByUserNameAsync(string userName) => await _userManager.FindByNameAsync(userName);
        public async Task<IEnumerable<ApplicationUser>> GetActiveUsersAsync() => await _dbSet.Where(x => x.Active).ToListAsync();
        public async Task<IEnumerable<ApplicationUser>?> GetAllUsersAsync() => await _dbSet.ToListAsync(); 
        public async Task<IEnumerable<ApplicationUser>> GetAllUsersByClaimAsync(Claim claim) => await _userManager.GetUsersForClaimAsync(claim);
        public async Task<IEnumerable<ApplicationUser>> GetAllUsersByRoleAsync(string roleName) => await _userManager.GetUsersInRoleAsync(roleName);

        public async Task<(IdentityResult, ApplicationUser)> AddUserAsync(ApplicationUser user, string password)
        {
            user.CreateDate = DateTime.Now;
            user.AlterDate = DateTime.Now;
            var createResult = await _userManager.CreateAsync(user, password);
            var userResult = await _userManager.FindByNameAsync(user.UserName);
            return (createResult, userResult);
        }

        public async Task<(IdentityResult, ApplicationUser)> UpdateUserAsync(int id, ApplicationUser user)
        {
            var userDataBase = _userManager.FindByIdAsync(id.ToString());

            user.AlterDate = DateTime.Now;
            var updateResult = await _userManager.UpdateAsync(user);
            return (updateResult, user);
        }

        public async Task<IdentityResult> DeleteUserByIdAsync(int id)
        {
            var userDatabase = await _userManager.FindByIdAsync(id.ToString());
            return userDatabase != null ? await DeleteUserAsync(userDatabase) : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteUserByUserNameAsync(string userName)
        {
            var userDatabase = await _userManager.FindByNameAsync(userName);
            return userDatabase != null ? await DeleteUserAsync(userDatabase) : IdentityResult.Failed();
        }

        private async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            if (user != null)
            {
                user.AlterDate = DateTime.Now;
                user.Active = false;
                await _userManager.SetLockoutEnabledAsync(user, true);
                return await _userManager.UpdateAsync(user);
            }
            return IdentityResult.Failed();
        }
    }
}
