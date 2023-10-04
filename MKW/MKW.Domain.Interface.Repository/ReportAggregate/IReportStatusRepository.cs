using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Interface.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Repository.ReportAggregate
{
    public interface IReportStatusRepository : IBaseRepository<ReportStatus>
    {
        Task<ReportStatus> GetByName(string name);
    }
}
