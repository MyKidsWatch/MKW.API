using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Domain.Entities.Base;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Data.Repository.Base
{
    /// <summary>
    /// Repositório de Base que adiciona operações de CRUD para a TEntity informada.
    /// Disponibiliza também a propriedade _dbSet para acesso à Tabela equivalente à TEntity na Base de Dados.
    /// </summary>
    /// <typeparam name="TEntity">Entidade que herda da BaseEntity</typeparam>
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
            entity.CreateDate = DateTime.Now;
            entity.AlterDate = DateTime.Now;
            var addedEntity = _dbSet.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            entity.AlterDate = DateTime.Now;
            var updatedEntity = _dbSet.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return updatedEntity;
        }

        public async Task Delete(TEntity entity)
        {
            entity.Active = false;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                entity.Active = false;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteByUUID(Guid uuid)
        {
            var entity = _dbSet.FirstOrDefault(x => x.UUID == uuid);

            if (entity != null)
            {
                entity.Active = false;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        protected async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
