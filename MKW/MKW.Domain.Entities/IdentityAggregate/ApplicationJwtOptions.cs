using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Entities.IdentityAggregate
{
    public class ApplicationJwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public SigningCredentials SigningCredentials { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
    }
}
