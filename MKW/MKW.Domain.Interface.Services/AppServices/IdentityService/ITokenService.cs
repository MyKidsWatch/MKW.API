using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Services.AppServices.IdentityService
{
    public interface ITokenService
    {
        Task<ApplicationToken> GetToken(IdentityUser<int> user, IList<Claim> claims, IList<string> roles);        
    }
}
