using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Interface.Repository.ReportAggregate;

namespace MKW.Data.Repository.ReportAggregate
{
    public class ReportReasonRepository : BaseRepository<ReportReason>, IReportReasonRepository
    {
        public ReportReasonRepository(MKWContext context) : base(context)
        {
        }
    }
}
