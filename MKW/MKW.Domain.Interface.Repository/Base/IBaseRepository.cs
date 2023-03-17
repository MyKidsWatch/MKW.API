using MKW.Domain.Entities.Base;

namespace MKW.Domain.Interface.Repository.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task DeleteById(int id);
    }
}
