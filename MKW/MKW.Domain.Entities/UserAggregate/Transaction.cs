using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class Transaction : BaseEntity
    {
        public int BalanceId { get; set; }
        public int Value { get; set; }
        public bool Operation { get; set; }
        public int CurrentBalance { get; set; }
        public int NewBalance { get; set; }
        public virtual Balance Balance { get; set; }
    }
}
