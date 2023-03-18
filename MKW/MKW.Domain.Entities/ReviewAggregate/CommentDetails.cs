using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class CommentDetails : BaseEntity
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
