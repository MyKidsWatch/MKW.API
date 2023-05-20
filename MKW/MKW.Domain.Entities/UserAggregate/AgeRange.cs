using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class AgeRange : BaseEntity
    {
        public int InitialAge { get; set; }
        public int FinalAge { get; set; }
        public virtual ICollection<PersonChild> Children { get; set; }
        public double GetMeanAge() => (InitialAge + FinalAge) / 2;
    }
}
