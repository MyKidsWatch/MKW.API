namespace MKW.Domain.Entities.IdentityAggregate
{
    public class ApplicationIdentityOptions
    {
        public AdminUser AdminUser { get; set; }
        public StandardRole StandardRole { get; set; }
        public AdminRole AdminRole { get; set; }
    }

    public class StandardRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

    }
    public class AdminRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

    }
    public class AdminUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }

    }
}
