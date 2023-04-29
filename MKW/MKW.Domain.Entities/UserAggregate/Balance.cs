using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class Balance : BaseEntity
    {
        public int PersonId { get; set; }
        public int StarCoins { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
