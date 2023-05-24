using FluentResults;
using Microsoft.AspNetCore.Identity;
using MKW.Domain.Entities.IdentityAggregate;
using System.Security.Claims;

namespace MKW.Domain.Interface.Services.AppServices.IdentityService
{
    public interface ITokenService
    {
        Task<Result<ApplicationToken>> GetToken(IdentityUser<int> user, IList<Claim> claims, IList<string> roles);
    }
}
