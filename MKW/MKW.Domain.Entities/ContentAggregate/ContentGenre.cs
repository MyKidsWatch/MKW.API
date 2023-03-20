using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ContentAggregate
{
    public class ContentGenre : BaseEntity
    {
        public int ContentId { get; set; }
        public int GenreId { get; set; }
        public virtual Content Content { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
