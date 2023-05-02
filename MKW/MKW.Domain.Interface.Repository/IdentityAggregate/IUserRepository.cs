using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IUserRepository<TIdentity> where TIdentity : IdentityUser<int>
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUserNameAsync(string userName);
        Task<IEnumerable<TIdentity>> GetActiveUsersAsync();
        Task<IEnumerable<TIdentity>> GetAllUsersAsync();
        Task<IEnumerable<TIdentity>> GetAllUsersByClaimAsync(Claim claim);
        Task<IEnumerable<TIdentity>> GetAllUsersByRoleAsync(string roleName);
        Task<(IdentityResult, TIdentity)> AddUserAsync(TIdentity user, string password);
        Task<(IdentityResult, TIdentity)> UpdateUserAsync(TIdentity user);
        Task<IdentityResult> DeleteUserAsync(TIdentity user);
        Task<IdentityResult> DeleteUserByIdAsync(int id);
        Task<IdentityResult> DeleteUserByUserNameAsync(string userName);
    }
}
