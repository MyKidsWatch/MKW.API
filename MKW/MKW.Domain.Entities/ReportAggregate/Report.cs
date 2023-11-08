using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Entities.ReportAggregate
{
    public class Report : BaseEntity
    {
        public int ReasonId { get; set; }
        public int StatusId { get; set; }
        public int PersonId { get; set; }
        public int? ReportedPersonId { get; set; }
        public int? ReviewId { get; set; }
        public int? CommentId { get; set; }
        public string? Details { get; set; }
        public virtual ReportReason Reason { get; set; }
        public virtual Review? Review { get; set; }
        public virtual Comment? Comment { get; set; }
        public virtual ReportStatus Status { get; set; }
        public virtual Person Person { get; set; }
        public virtual Person? ReportedPerson { get; set; }
    }
}
