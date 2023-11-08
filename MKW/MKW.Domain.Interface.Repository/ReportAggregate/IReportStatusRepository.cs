using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.ReportAggregate
{
    public interface IReportStatusRepository : IBaseRepository<ReportStatus>
    {
        Task<ReportStatus> GetByName(string name);
    }
}
