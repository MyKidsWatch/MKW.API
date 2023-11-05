using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.Base;

namespace MKW.Domain.Interface.Repository.ReviewAggregate
{
    /// <summary>
    /// Repositório para a entidade Comment. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetByReviewId(int reviewId);
    }
}
