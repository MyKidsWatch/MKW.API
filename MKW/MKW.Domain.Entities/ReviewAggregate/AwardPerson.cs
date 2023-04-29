using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class AwardPerson : BaseEntity
    {
        public int PersonId { get; set; }
        public int ReviewId { get; set; }
        public int AwardId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Review Review { get; set; }
        public virtual Award Award { get; set; }
    }
}
