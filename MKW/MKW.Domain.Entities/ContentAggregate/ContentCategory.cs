using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ContentAggregate
{
    public class ContentCategory : BaseEntity
    {
        public string Name { get; set; }
        public int PlatformId { get; set; }
        public virtual Platform Platform { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}
