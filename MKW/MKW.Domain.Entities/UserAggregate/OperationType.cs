using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class OperationType : BaseEntity
    {
        public string Type { get; set; }
        public bool Operation { get; set; }
        public virtual ICollection<Operation> Transactions { get; set; }
    }
}
