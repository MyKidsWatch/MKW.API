using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MKW.Data.Context;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.Identity;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using MKW.Services.AppServices.IdentityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace MKW.IoC.Modules
{
    public static class IdentityModule
    {
        public static void AddAuthentication(this IServiceCollection builder, IConfiguration configuration)
        {
            builder.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole<int>>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddEntityFrameworkStores<MKWContext>()
                .AddDefaultTokenProviders();


            var jwtOptionsSettings = configuration.GetSection(nameof(ApplicationJwtOptions));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("ApplicationJwtOptions:SecurityKey").Value));

            builder.Configure<ApplicationJwtOptions>(options =>
            {
                options.Issuer = jwtOptionsSettings[nameof(ApplicationJwtOptions.Issuer)];
                options.Audience = jwtOptionsSettings[nameof(ApplicationJwtOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                options.Expiration = int.Parse(jwtOptionsSettings[nameof(ApplicationJwtOptions.Expiration)] ?? "0");
            });

            builder.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
                options.Lockout.MaxFailedAccessAttempts = 5;
            });

            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            builder.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationParameter;
                });

            var applicationIdentityOptions = ApplicationIdentityOptions(configuration);


            builder.Configure<ApplicationIdentityOptions>(options =>
            {
                options.AdminUser = applicationIdentityOptions.AdminUser;
                options.StandardRole = applicationIdentityOptions.StandardRole;
                options.AdminRole = applicationIdentityOptions.AdminRole;

            });


            builder.AddTransient<ITokenService, TokenService>();
            builder.AddTransient<IAccountService, AccountService>();
            builder.AddTransient<IAuthService, AuthenticationService>();
            builder.AddTransient<IRoleService, RoleService>();
        }
        private static ApplicationIdentityOptions ApplicationIdentityOptions(IConfiguration configuration)
        {
            var adminUserSection = configuration.GetSection("IdentityOptions:AdminUser");
            var adminUser = new AdminUser()
            {
                Id = int.Parse(adminUserSection[nameof(AdminUser.Id)]),
                FirstName = adminUserSection[nameof(AdminUser.FirstName)],
                LastName = adminUserSection[nameof(AdminUser.LastName)],
                UserName = adminUserSection[nameof(AdminUser.UserName)],
                NormalizedUserName = adminUserSection[nameof(AdminUser.NormalizedUserName)],
                Email = adminUserSection[nameof(AdminUser.Email)],
                NormalizedEmail = adminUserSection[nameof(AdminUser.NormalizedEmail)],
                EmailConfirmed = bool.Parse(adminUserSection[nameof(AdminUser.EmailConfirmed)]),
                PhoneNumber = adminUserSection[nameof(AdminUser.PhoneNumber)],
                PhoneNumberConfirmed = bool.Parse(adminUserSection[nameof(AdminUser.PhoneNumberConfirmed)]),
                TwoFactorEnabled = bool.Parse(adminUserSection[nameof(AdminUser.TwoFactorEnabled)]),
                LockoutEnabled = bool.Parse(adminUserSection[nameof(AdminUser.LockoutEnabled)]),
                Active = bool.Parse(adminUserSection[nameof(AdminUser.Active)]),
                Password = adminUserSection[nameof(AdminUser.Password)],
            };

            var standardRoleSection = configuration.GetSection("IdentityOptions:StandardRole");
            var standardRole = new StandardRole()
            {
                Id = int.Parse(standardRoleSection[nameof(StandardRole.Id)]),
                Name = standardRoleSection[nameof(StandardRole.Name)],
                NormalizedName = standardRoleSection[nameof(StandardRole.NormalizedName)],
            };

            var adminRoleSection = configuration.GetSection("IdentityOptions:AdminRole");
            var adminRole = new AdminRole()
            {
                Id = int.Parse(adminRoleSection[nameof(AdminRole.Id)]),
                Name = adminRoleSection[nameof(AdminRole.Name)],
                NormalizedName = adminRoleSection[nameof(AdminRole.NormalizedName)],
            };
            return new ApplicationIdentityOptions()
            {
               AdminUser = adminUser,
               StandardRole = standardRole,
               AdminRole = adminRole
            };
        }
    }
}
