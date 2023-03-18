using MKW.Domain.Entities.Base;

namespace MKW.Domain.Interface.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>?> GetAll();
        Task<TEntity?> GetById(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        Task DeleteById(int id);
    }
}
