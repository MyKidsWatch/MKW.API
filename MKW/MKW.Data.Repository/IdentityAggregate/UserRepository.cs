using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using System.Security.Claims;

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

        public async Task<(Result, ApplicationUser?)> GetUserByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return user is null ? (Result.Fail("user not found"), null) : (Result.Ok(), user);
        }
        public async Task<(Result, ApplicationUser?)> GetUserByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user is null ? (Result.Fail("user not found"), null) : (Result.Ok(), user);
        }
        public async Task<(Result result, ApplicationUser? user)> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user is null ? (Result.Fail("user not found"), null) : (Result.Ok(), user);
        }

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

            var userEntity = await _userManager.FindByIdAsync(id.ToString());
            if (userEntity is null) return (IdentityResult.Failed(), null);

            if (user.FirstName is not null) userEntity.FirstName = user.FirstName;
            if (user.LastName is not null) userEntity.LastName = user.LastName;
            if (user.UserName is not null)
            {
                userEntity.UserName = user.UserName;
                userEntity.NormalizedUserName = user.UserName.ToUpper();
            }
            if (user.PhoneNumber is not null)
            {
                userEntity.PhoneNumber = user.PhoneNumber;
                userEntity.PhoneNumberConfirmed = false;
            }
            if (user.Email is not null) 
            {
                userEntity.Email = user.Email;
                userEntity.NormalizedEmail = user.Email.ToUpper();
                userEntity.EmailConfirmed = false;
            }

            userEntity.AlterDate = DateTime.Now;
            var updateResult = await _userManager.UpdateAsync(userEntity);
            return (updateResult, userEntity);
        }

        public async Task<IdentityResult> DeleteUserByIdAsync(int id)
        {
            var userDatabase = await _userManager.FindByIdAsync(id.ToString());
            return userDatabase != null ? await DeleteUserAsync(userDatabase) : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteUserByUserNameAsync(string username)
        {
            var userDatabase = await _userManager.FindByNameAsync(username);
            return userDatabase != null ? await DeleteUserAsync(userDatabase) : IdentityResult.Failed();
        }

        public async Task<Result> ConfirmAccountEmailAsync(int userId, string activationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is not null)
            {
                var confirmEmail = await _userManager.ConfirmEmailAsync(user, activationToken);
                return confirmEmail.Succeeded ? Result.Ok() : Result.Fail("Failed to confirm email");
            }
            return Result.Fail("user not found");
        }

        public async Task<(Result, string?)> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return token is null ? (Result.Fail("Failed to generate confirmation token"), null) : (Result.Ok(), token);
        }

        public async Task<Result> SetUserLockoutEndDateAsync(ApplicationUser user, DateTimeOffset dateTimeOffset)
        {
            string message = dateTimeOffset > DateTimeOffset.Now ? "block" : "unblock";
            var BlockResult = await _userManager.SetLockoutEndDateAsync(user, dateTimeOffset);
            return BlockResult.Succeeded ? Result.Ok().WithSuccess($"lockouEnd: {message}") : Result.Fail("Failed to set lockoutEnd date");
        }

        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string newPassword)
        {
            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }

        public async Task<(Result, string?)> RequestPasswordKeycodeAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                var recoveryToken = _userManager.GeneratePasswordResetTokenAsync(user);
                return (Result.Ok(), recoveryToken.Result);
            }
            return (Result.Fail("email not registered"), null);
        }

        private async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            if (user != null)
            {
                user.AlterDate = DateTime.Now;
                user.Active = false;
                await _userManager.UpdateAsync(user);
                return await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
            }
            return IdentityResult.Failed();
        }
    }
}
