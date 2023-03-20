using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Entities.ContentAggregate
{
    public class Content : BaseEntity
    {
        public string Name { get; set; }
        public int PlatformCategoryId { get; set; }
        public virtual PlatformCategory PlatformCategory { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<ContentGenre> ContentGenre { get; set; }
    }
}
