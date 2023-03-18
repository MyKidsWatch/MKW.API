using Microsoft.EntityFrameworkCore;
using MKW.Data.Infra;
using MKW.Domain.Entities.Base;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Services.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MKWContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(MKWContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>?> GetAll() => await _dbSet.ToListAsync();
        public async Task<IEnumerable<TEntity>?> GetActive() => await _dbSet.Where(x => x.Active).ToListAsync();
        public async Task<TEntity?> GetById(int id) => await _dbSet.FindAsync(id);
        public async Task<TEntity?> GetByUUID(Guid uuid) => await _dbSet.FirstOrDefaultAsync(x => x.UUID == uuid);

        public async Task<TEntity> Add(TEntity entity)
        {
            var addedEntity = _dbSet.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var updatedEntity = _dbSet.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null) _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        protected async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
