using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.PremiumAggregate;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Entities.UserAggregate
{
    public class Person : BaseEntity
    {
        public string? ImageURL { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserId { get; set; }
        public int GenderId { get; set; }
        public int Balance { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<PersonChild> Children { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PremiumPerson> PremiumPerson { get; set; }
        public virtual ICollection<AwardPerson> AwardsGiven { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
