using MKW.Domain.Entities.Base;

namespace MKW.Domain.Interface.Services.AppServices.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task AddRange(params T[] entities);
        Task UpdateRange(params T[] entities);
        Task<bool> Delete(int id);
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Update(T entity);
    }
}