using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class Operation : BaseEntity
    {
        public int PersonId { get; set; }
        public int OperationTypeId { get; set; }
        public int Coins { get; set; }
        public virtual Person Person { get; set; }
        public virtual OperationType OperationType { get; set; }
    }
}
