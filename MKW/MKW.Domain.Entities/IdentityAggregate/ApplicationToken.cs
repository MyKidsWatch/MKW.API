namespace MKW.Domain.Entities.IdentityAggregate
{
    public class ApplicationToken
    {
        public ApplicationToken(string accessTokenValue, string refreshTokenValue)
        {
            AccessToken = accessTokenValue;
            RefreshToken = refreshTokenValue;
        }
        public string AccessToken { get; }
        public string RefreshToken { get; }
    }
}
