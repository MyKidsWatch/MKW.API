using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Domain.Entities.ReviewAggregate
{
    public class Review : BaseEntity
    {
        public int PersonId { get; set; }
        public int ContentId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Content Content { get; set; }
        public virtual ICollection<ReviewDetails> ReviewDetails { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<AwardPerson> Awards { get; set; }
        public virtual ICollection<Report> Reports { get; set; }

        public int GoldenAwards => Awards?.Count(x => x.Award.Name == "Gold") ?? 0;
        public int SilverAwards => Awards?.Count(x => x.Award.Name == "Silver") ?? 0;
        public int BronzeAwards => Awards?.Count(x => x.Award.Name == "Bronze") ?? 0;
    }
}
