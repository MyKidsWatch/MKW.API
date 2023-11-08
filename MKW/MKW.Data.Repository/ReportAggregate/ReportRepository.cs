using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AnyReportByUser(int personId, int? reviewId, int? commentId, int? reportedPersonId)
            => await _dbSet.AnyAsync(x => x.PersonId == personId 
                && (reviewId == null || x.ReviewId == reviewId) 
                && (commentId == null || x.CommentId == commentId)
                && (reportedPersonId == null || x.ReportedPersonId == reportedPersonId)
            );
    }
}
