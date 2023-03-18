using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Entities.ContentAggregate
{
    public class Content : BaseEntity
    {
        public string Name { get; set; }
        public int ContentCategoryId { get; set; }
        public virtual ContentCategory ContentCategory { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
