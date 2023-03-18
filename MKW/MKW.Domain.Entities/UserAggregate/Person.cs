using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.PremiumAggregate;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Entities.UserAggregate
{
    public class Person : BaseEntity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public int PhoneCountry { get; set; }
        public string PhoneArea { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<PersonChild> Children { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PremiumPerson> PremiumPerson { get; set; }
    }
}
