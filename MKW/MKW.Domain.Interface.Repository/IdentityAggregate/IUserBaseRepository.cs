using Microsoft.AspNetCore.Identity;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IUserBaseRepository<TIdentity> where TIdentity : IdentityUser<int>
    {
        Task<ApplicationUser?> GetUserByIdAsync(int id);
        Task<ApplicationUser?> GetUserByUserNameAsync(string userName);
        Task<IEnumerable<TIdentity>> GetActiveUsersAsync();
        Task<IEnumerable<TIdentity>> GetAllUsersAsync();
        Task<IEnumerable<TIdentity>> GetAllUsersByClaimAsync(Claim claim);
        Task<IEnumerable<TIdentity>> GetAllUsersByRoleAsync(string roleName);
        Task<(IdentityResult result, TIdentity user)> AddUserAsync(TIdentity user, string password);
        Task<(IdentityResult result, TIdentity user)> UpdateUserAsync(int id, TIdentity user);
        Task<IdentityResult> DeleteUserByIdAsync(int id);
        Task<IdentityResult> DeleteUserByUserNameAsync(string userName);
    }
}
