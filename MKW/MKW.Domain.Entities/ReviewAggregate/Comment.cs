using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class Comment : BaseEntity
    {
        public int PersonId { get; set; }
        public int PostId { get; set; }
        public int? ParentComentId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Post Post { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> Answers { get; set; }
        public virtual ICollection<CommentDetails> CommentDetails { get; set; }

    }
}
