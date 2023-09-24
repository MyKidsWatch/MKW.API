using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Interface.Repository.ReportAggregate;
using MKW.Domain.Utility.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Data.Repository.ReportAggregate
{
    public class ReportStatusRepository : BaseRepository<ReportStatus>, IReportStatusRepository
    {
        public ReportStatusRepository(MKWContext context) : base(context)
        {
        }

        public async Task<ReportStatus> GetByName(string name) => await _dbSet.FirstOrDefaultAsync(x => x.Name == name) ?? throw new NotFoundException("Report status not found");
    }
}
