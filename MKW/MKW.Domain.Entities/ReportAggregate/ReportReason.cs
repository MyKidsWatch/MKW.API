using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ReportAggregate
{
    public class ReportReason : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
