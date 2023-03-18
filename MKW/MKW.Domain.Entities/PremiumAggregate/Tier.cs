using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.PremiumAggregate
{
    public class Tier : BaseEntity
    {
        public string Name { get; set; }
        public bool IsPremium { get; set; }
        public virtual ICollection<TierPlan> TierPlans { get; set; }
    }
}
