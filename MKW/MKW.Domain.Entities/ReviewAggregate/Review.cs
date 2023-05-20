using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class Review : BaseEntity
    {
        public int PersonId { get; set; }
        public int ContentId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Content Content { get; set; }
        public virtual ICollection<ReviewDetails> ReviewDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<AwardPerson> Awards { get; set; }
    }
}
