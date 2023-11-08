using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ReportAggregate
{
    public class ReportStatus : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
