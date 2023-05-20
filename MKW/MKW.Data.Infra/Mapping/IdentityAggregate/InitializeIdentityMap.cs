using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.IdentityAggregate;

namespace MKW.Data.Context.Mapping.IdentityAggregate
{
    public class InitializeIdentityMap
    {
        public static void Map(ModelBuilder modelBuilder, ApplicationIdentityOptions identityOptions)
        {
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("TB_USR_USERS");

            modelBuilder.Entity<IdentityRole<int>>()
                .ToTable("TB_USR_ROLES");

            modelBuilder.Entity<IdentityUserRole<int>>()
                .ToTable("TB_USR_USER_ROLE");

            modelBuilder.Entity<IdentityUserLogin<int>>()
                .ToTable("TB_USR_USER_LOGIN");

            modelBuilder.Entity<IdentityUserToken<int>>()
                .ToTable("TB_USR_USER_TOKEN");

            modelBuilder.Entity<IdentityUserClaim<int>>()
                .ToTable("TB_USR_USER_CLAIM");

            modelBuilder.Entity<IdentityRoleClaim<int>>()
                .ToTable("TB_USR_ROLE_CLAIM");

            ApplicationUser admin = new ApplicationUser()
            {
                Id = identityOptions.AdminUser.Id,
                FirstName = identityOptions.AdminUser.FirstName,
                LastName = identityOptions.AdminUser.LastName,
                UserName = identityOptions.AdminUser.UserName,
                NormalizedUserName = identityOptions.AdminUser.NormalizedUserName,
                Email = identityOptions.AdminUser.Email,
                NormalizedEmail = identityOptions.AdminUser.NormalizedEmail,
                EmailConfirmed = identityOptions.AdminUser.EmailConfirmed,
                CreateDate = DateTime.Now,
                LockoutEnabled = identityOptions.AdminUser.LockoutEnabled,
                SecurityStamp = Guid.NewGuid().ToString(),
                Active = identityOptions.AdminUser.Active,
                PhoneNumber = identityOptions.AdminUser.PhoneNumber,
                PhoneNumberConfirmed = identityOptions.AdminUser.PhoneNumberConfirmed,
                TwoFactorEnabled = identityOptions.AdminUser.TwoFactorEnabled,
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, identityOptions.AdminUser.Password);

            IdentityRole<int> AdminRole = new IdentityRole<int>()
            {
                Id = identityOptions.AdminRole.Id,
                Name = identityOptions.AdminRole.Name,
                NormalizedName = identityOptions.AdminRole.NormalizedName,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityRole<int> StandardRole = new IdentityRole<int>()
            {
                Id = identityOptions.StandardRole.Id,
                Name = identityOptions.StandardRole.Name,
                NormalizedName = identityOptions.StandardRole.NormalizedName,
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityUserRole<int> AdminUserBidingAdminRole = new IdentityUserRole<int>()
            {
                RoleId = identityOptions.AdminRole.Id,
                UserId = identityOptions.AdminUser.Id
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(AdminRole);
            modelBuilder.Entity<IdentityRole<int>>().HasData(StandardRole);
            modelBuilder.Entity<ApplicationUser>().HasData(admin);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(AdminUserBidingAdminRole);
        }
    }
}
