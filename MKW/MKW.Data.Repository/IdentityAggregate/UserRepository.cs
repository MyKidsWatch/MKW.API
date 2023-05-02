using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Domain.Entities.Identity;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Data.Repository.IdentityAggregate
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly MKWContext _context;
        protected readonly DbSet<User> _dbSet;
        protected readonly UserManager<User> _userManager;
        public UserRepository(MKWContext context, UserManager<User> userManager)
        {
            _context = context;
            _dbSet = _context.Set<User>();
            _userManager = userManager;
        }

        public async Task<User?> GetUserByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<User?> GetUserByUserNameAsync(string userName) => await _userManager.FindByNameAsync(userName);
        public async Task<IEnumerable<User>> GetActiveUsersAsync() => await _dbSet.Where(x => x.Active).ToListAsync();
        public async Task<IEnumerable<User>> GetAllUsersAsync() => await _dbSet.ToListAsync(); 
        public async Task<IEnumerable<User>> GetAllUsersByClaimAsync(Claim claim) => await _userManager.GetUsersForClaimAsync(claim);
        public async Task<IEnumerable<User>> GetAllUsersByRoleAsync(string roleName) => await _userManager.GetUsersInRoleAsync(roleName);

        public async Task<(IdentityResult, User)> AddUserAsync(User user, string password)
        {
            user.CreateDate = DateTime.Now;
            user.AlterDate = DateTime.Now;
            var createResult = await _userManager.CreateAsync(user, password);
            return (createResult, createdUser: user);
        }

        public async Task<(IdentityResult, User)> UpdateUserAsync(User user)
        {
            user.AlterDate = DateTime.Now;
            var updateResult = await _userManager.UpdateAsync(user);
            return (updateResult, updatedUser: user);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            //TODO: rever chamada dupla no banco quando ById ou ByUserName
            var userDatabase = await _dbSet.FindAsync(user);

            if (userDatabase != null)
            {
                userDatabase.Active = false;
                await _userManager.SetLockoutEnabledAsync(userDatabase, true);
                return await _userManager.UpdateAsync(userDatabase);
            }
            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteUserByIdAsync(int id)
        {
            var userDatabase = await _dbSet.FindAsync(id);
            return userDatabase != null ? await DeleteUserAsync(userDatabase) : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteUserByUserNameAsync(string userName)
        {
            var userDatabase = await _userManager.FindByNameAsync(userName);
            return userDatabase != null ? await DeleteUserAsync(userDatabase) : IdentityResult.Failed();
        }

        protected async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
