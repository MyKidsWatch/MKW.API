using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.ContentAggregate;

namespace MKW.Data.Repository.ContentAggregate
{
    /// <summary>
    /// Repositório para a entidade Content. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {
        public ContentRepository(MKWContext context) : base(context) { }

        public async Task<Content?> GetContentByExternalId(string externalId, int? platformId = null)
            => await _dbSet
            .Include(x => x.Reviews)
            .Include(x => x.Reviews)
            .ThenInclude(x => x.ReviewDetails)
            .FirstOrDefaultAsync(x => x.ExternalId == externalId && (platformId == null || x.PlatformCategory.PlatformId == platformId));

        public async Task<IEnumerable<Content?>> GetContentsByExternalId(IEnumerable<string> externalIds, int? platformId = null)
            => await _dbSet
            .AsNoTracking()
            .Include(x => x.Reviews)
            .Include(x => x.Reviews)
            .ThenInclude(x => x.ReviewDetails)
            .Where(x => externalIds.Contains(x.ExternalId) && (platformId == null || x.PlatformCategory.PlatformId == platformId))
            .ToListAsync();
    }
}
