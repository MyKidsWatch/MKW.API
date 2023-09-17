using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class ReviewDetails : BaseEntity
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
        public virtual Review Review { get; set; }
    }
}
