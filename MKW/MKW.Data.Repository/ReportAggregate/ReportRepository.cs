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
        {
            if (commentId is not null) return await _dbSet.AnyAsync(x => x.PersonId == personId && x.CommentId == commentId);
            if (reviewId is not null) return await _dbSet.AnyAsync(x => x.PersonId == personId && x.ReviewId == reviewId && x.CommentId == null);
            if (reportedPersonId is not null) return await _dbSet.AnyAsync(x => x.PersonId == personId && x.ReportedPersonId == reportedPersonId && x.ReviewId == null && x.CommentId == null);
            else return false;
        }
    }
}
