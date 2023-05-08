using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MKW.Services.AppServices.IdentityService
{
    public class TokenService : ITokenService
    {
        private readonly ApplicationJwtOptions _jwtOptions;

        public TokenService(IOptions<ApplicationJwtOptions> JwtOptions)
        {
            _jwtOptions = JwtOptions.Value;
        }
        public async Task<Result<ApplicationToken>> GetToken(IdentityUser<int> user, IList<Claim> claims, IList<string> roles)
        {
            //TODO: ARRUMAR TRY-CATCH
            try
            {
                var userClaimsRights = await getUserClaims(user, claims, roles);
                var expirationDate = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

                var token = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    claims: userClaimsRights,
                    notBefore: DateTime.Now,
                    expires: expirationDate,
                    signingCredentials: _jwtOptions.SigningCredentials
                );

                var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Result.Ok<ApplicationToken>(new ApplicationToken(generatedToken, expirationDate));
            }
            catch (Exception ex)
            {
                return Result.Fail<ApplicationToken>($"{ex.Message}");
            }
        }

        private async Task<IEnumerable<Claim>> getUserClaims(IdentityUser<int> user, IList<Claim> claims, IList<string> roles)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); //Json Token Identifier
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString())); //Not Before
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())); //Issued at

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
    }
}
