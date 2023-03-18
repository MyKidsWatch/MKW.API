using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class PersonChild : BaseEntity
    {
        public int PersonId { get; set; }
        public int GenderId { get; set; }
        public int AgeRangeId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual AgeRange AgeRange { get; set; }
    }
}
