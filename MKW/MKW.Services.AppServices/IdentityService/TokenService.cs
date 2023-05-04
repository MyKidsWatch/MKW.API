using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
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
        public async Task<ApplicationToken> GetToken(IdentityUser<int> user, IList<Claim> claims, IList<string> roles)
        {
            var _JwtOptions = new ApplicationJwtOptions();
            var userClaimsRights = await getUserClaims(user, claims, roles);
            var expirationDate = DateTime.Now.AddSeconds(_JwtOptions.Expiration);

            var token = new JwtSecurityToken(
                issuer: _JwtOptions.Issuer,
                audience: _JwtOptions.Audience,
                claims: userClaimsRights,
                notBefore: DateTime.Now,
                expires: expirationDate,
                signingCredentials: _JwtOptions.SigningCredentials
            );

            var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new ApplicationToken(generatedToken, expirationDate);
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
                claims.Add(new Claim("role", role));
            }

            return claims;
        }
    }
}
