using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.PremiumAggregate
{
    public class Timespan : BaseEntity
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public virtual ICollection<TierPlan> TierPlans { get; set; }
    }
}
