using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Entities.PremiumAggregate
{
    public class PremiumPerson : BaseEntity
    {
        public int PersonId { get; set; }
        public int TierPlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool AutoRenewal { get; set; }
        public virtual Person Person { get; set; }
        public virtual TierPlan TierPlan { get; set; }
    }
}
