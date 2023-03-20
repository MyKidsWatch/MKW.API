using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ContentAggregate
{
    public class Platform : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual ICollection<ContentCategory> ContentCategories { get; set; }
    }
}
