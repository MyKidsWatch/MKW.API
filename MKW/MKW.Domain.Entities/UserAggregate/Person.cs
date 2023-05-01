using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.Identity;
using MKW.Domain.Entities.PremiumAggregate;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Entities.UserAggregate
{
    public class Person : BaseEntity
    {
        public DateOnly BirthDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Balance Balance { get; set; }
        public virtual ICollection<PersonChild> Children { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PremiumPerson> PremiumPerson { get; set; }
        public virtual ICollection<AwardPerson> AwardsGiven { get; set; }
    }
}
