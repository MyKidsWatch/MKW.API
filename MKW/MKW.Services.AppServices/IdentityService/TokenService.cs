using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
                var userClaimsRights = getUserClaims(user, claims, roles);
                var tokens = GenerateSecurityToken(userClaimsRights.accessClaims, userClaimsRights.refreshClaims);

                var generatedAccessToken = new JwtSecurityTokenHandler().WriteToken(tokens.accessToken);
                var generatedRefreshToken = new JwtSecurityTokenHandler().WriteToken(tokens.refreshToken);

                return Result.Ok<ApplicationToken>(new ApplicationToken(generatedAccessToken, generatedRefreshToken, tokens.accessExpiration, tokens.refreshExpiration));
            }
            catch (Exception ex)
            {
                return Result.Fail<ApplicationToken>($"{ex.Message}");
            }
        }

        private (IEnumerable<Claim> accessClaims, IEnumerable<Claim> refreshClaims) getUserClaims(IdentityUser<int> user, IList<Claim> userClaims, IList<string> roles)
        {
            var accessClaims = new List<Claim>();

            accessClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            accessClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            accessClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); //Json Token Identifier
            accessClaims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString())); //Not Before
            accessClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())); //Issued at

            var refreshClaims = new List<Claim>(accessClaims);

            foreach (var userClaim in userClaims)
            {
                accessClaims.Add(userClaim);
            }

            foreach (var role in roles)
            {
                accessClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            return (accessClaims, refreshClaims);
        }

        private (JwtSecurityToken accessToken, JwtSecurityToken refreshToken, DateTime accessExpiration, DateTime refreshExpiration)
            GenerateSecurityToken(IEnumerable<Claim> accessClaims, IEnumerable<Claim> refreshClaims)
        {
            var accessTokenExpiration = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

            var accessToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: accessClaims,
                notBefore: DateTime.Now,
                expires: accessTokenExpiration,
                signingCredentials: _jwtOptions.SigningCredentials
            );

            var refreshToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: refreshClaims,
                notBefore: DateTime.Now,
                expires: refreshTokenExpiration,
                signingCredentials: _jwtOptions.SigningCredentials
            );

            return (accessToken, refreshToken, accessTokenExpiration, refreshTokenExpiration);
        }
    }
}
