using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.PremiumAggregate
{
    public class TierPlan : BaseEntity
    {
        public int TierId { get; set; }
        public int TimespanId { get; set; }
        public int Price { get; set; }
        public virtual Tier Tier { get; set; }
        public virtual Timespan Timespan { get; set; }
        public virtual ICollection<PremiumPerson> PremiumPerson { get; set; }

    }
}
