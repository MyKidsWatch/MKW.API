using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class OperationType : BaseEntity
    {
        public string Type { get; set; }
        public bool Credit { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
