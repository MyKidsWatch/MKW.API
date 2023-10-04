using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.ReportAggregate
{
    public interface IReportRepository : IBaseRepository<Report>
    {
        Task<bool> AnyReportByUser(int personId, int? reviewId, int? commentId);
    }
}
