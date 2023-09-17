using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class Comment : BaseEntity
    {
        public int PersonId { get; set; }
        public int? ReviewId { get; set; }
        public int? ParentCommentId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Review Review { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> Answers { get; set; }
        public virtual ICollection<CommentDetails> CommentDetails { get; set; }

        public bool IsFirstLevel() => ReviewId != null && ParentCommentId == null;
    }
}
