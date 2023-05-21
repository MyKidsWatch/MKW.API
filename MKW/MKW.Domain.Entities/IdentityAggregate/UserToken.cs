namespace MKW.Domain.Entities.IdentityAggregate
{
    public class UserToken
    {
        public int UserId { get; set; }
        public int KeyCode { get; set; }
        public string Token { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
