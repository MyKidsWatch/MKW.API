using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class Award : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Value { get; set; }
        public string StripeId { get; set; }
        public virtual ICollection<AwardPerson> AwardPerson { get; set; }
    }
}
