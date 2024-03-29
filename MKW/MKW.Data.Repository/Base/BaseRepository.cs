﻿using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Domain.Entities.Base;
using MKW.Domain.Interface.Repository.Base;
using MKW.Domain.Utility.Abstractions;
using System.Linq.Expressions;

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

        public virtual async Task<IEnumerable<TEntity>?> GetAll() => await _dbSet.ToListAsync();
        public virtual async Task<IEnumerable<TEntity>?> GetActive() => await _dbSet.Where(x => x.Active).ToListAsync();
        public virtual async Task<PagedList<TEntity>> GetPaged<TKey>(Expression<Func<TEntity, bool>>? predicate = null, int page = 1, int pageSize = 10, Func<TEntity, TKey> order = null, bool asc = true)
        {
            var query = _dbSet.Where(predicate ?? (x => true));
            query = asc ? query.OrderBy(order).AsQueryable() : query.OrderByDescending(order).AsQueryable();
            query = query.Skip(pageSize * (page - 1)).Take(pageSize);

            return new PagedList<TEntity>()
            {
                Results = query.ToList(),
                Page = page,
                PageSize = pageSize,
                PageCount = (int)Math.Ceiling(await _dbSet.Where(predicate ?? (x => true)).CountAsync() / (decimal)pageSize)
            };
        }

        public virtual async Task<PagedList<TEntity>> GetPaged(Expression<Func<TEntity, bool>>? predicate = null, int page = 1, int pageSize = 10)
              => new PagedList<TEntity>()
              {
                  Results = _dbSet.Where(predicate ?? (x => true)).Skip(pageSize * (page - 1)).Take(pageSize).ToList(),
                  Page = page,
                  PageSize = pageSize,
                  PageCount = (int)Math.Ceiling(await _dbSet.Where(predicate ?? (x => true)).CountAsync() / (decimal)pageSize)
              };

        public virtual async Task<TEntity?> GetById(int id) => await _dbSet.FindAsync(id);
        public virtual async Task<TEntity?> GetByUUID(Guid uuid) => await _dbSet.FirstOrDefaultAsync(x => x.UUID == uuid);

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            entity.UUID = Guid.NewGuid();
            entity.CreateDate = DateTime.Now;
            entity.AlterDate = null;
            var addedEntity = _dbSet.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public virtual async Task AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.UUID = Guid.NewGuid();
                entity.CreateDate = DateTime.Now;
                entity.AlterDate = null;
            }

            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AddRange(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                entity.UUID = Guid.NewGuid();
                entity.CreateDate = DateTime.Now;
                entity.AlterDate = null;
            }

            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            entity.AlterDate = DateTime.Now;
            var updatedEntity = _dbSet.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return updatedEntity;
        }

        public virtual async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.AlterDate = DateTime.Now;
            }

            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateRange(params TEntity[] entities)
        {
            foreach (var entity in entities)
            {
                entity.AlterDate = DateTime.Now;
            }

            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            entity.Active = false;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteById(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                entity.Active = false;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteByUUID(Guid uuid)
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
