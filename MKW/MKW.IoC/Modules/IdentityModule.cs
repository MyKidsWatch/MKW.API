using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MKW.Data.Context;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using MKW.Services.AppServices.IdentityService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.IoC.Modules
{
    public static class IdentityModule
    {
        public static void AddAuthentication(this IServiceCollection builder, IConfiguration configuration)
        {
            builder.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<MKWContext>()
                .AddDefaultTokenProviders();

            var jwtOptionsSettings = configuration.GetSection("JwtOptions");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtOptions:SecurityKey").Value));

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
            });

            var tokenValidationParameter = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = true,

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

            builder.AddTransient<ITokenService, TokenService>();
        }
    } 
}
