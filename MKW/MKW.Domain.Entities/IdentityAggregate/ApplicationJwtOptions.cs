using Microsoft.IdentityModel.Tokens;

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
