using Microsoft.AspNetCore.Identity;
using MKW.Domain.Entities.IdentityAggregate;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IRoleRepository
    {
        Task<IEnumerable<IdentityRole<int>>> GetRolesAsync();
        Task<(IdentityResult result, IdentityRole<int>? role)> GetRoleByNameAsync(string roleName);
        Task<IdentityResult> AddUserToRoleAsync(string roleName, ApplicationUser user);
        Task<IdentityResult> DeleteUserFromRoleAsync(string roleName, ApplicationUser user);
    }
}
