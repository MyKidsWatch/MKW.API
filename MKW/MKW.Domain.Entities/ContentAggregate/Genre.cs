using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ContentAggregate
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ContentGenre> ContentGenre { get; set; }
    }
}
