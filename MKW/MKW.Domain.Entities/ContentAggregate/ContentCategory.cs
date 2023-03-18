using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ContentAggregate
{
    public class ContentCategory : BaseEntity
    {
        public string Name { get; set; }
        public int SourceId { get; set; }
        public virtual Source Source { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}
