namespace MKW.Domain.Entities.IdentityAggregate
{
    public class ApplicationToken
    {
        public ApplicationToken(
            string accessTokenValue,
            string refreshTokenValue,
            DateTime accessExpiration,
            DateTime refreshExpiration)
        {
            AccessToken = accessTokenValue;
            RefreshToken = refreshTokenValue;
            AccessTokenExpiration = accessExpiration;
            RefreshTokenExpiration = refreshExpiration;
        }
        public string AccessToken { get; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
