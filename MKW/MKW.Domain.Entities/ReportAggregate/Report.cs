using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Entities.ReportAggregate
{
    public class Report : BaseEntity
    {
        public int ReasonId { get; set; }
        public int? ReviewId { get; set; }
        public int? CommentId { get; set; }
        public string? Details { get; set; }
        public virtual ReportReason Reason { get; set; }
        public virtual Review? Review { get; set; }
        public virtual Comment? Comment { get; set; }
    }
}
