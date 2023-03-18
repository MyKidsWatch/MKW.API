using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class PostDetails : BaseEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public virtual Post Post { get; set; }
    }
}
