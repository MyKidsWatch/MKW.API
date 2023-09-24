using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Interface.Repository.ReportAggregate;

namespace MKW.Data.Repository.ReportAggregate
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(MKWContext context) : base(context)
        {
        }
    }
}
