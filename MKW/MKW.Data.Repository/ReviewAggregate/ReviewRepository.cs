using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Data.Repository.Base;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;

namespace MKW.Data.Repository.ReviewAggregate
{
    /// <summary>
    /// Repositório para a entidade Post. Disponibiliza métodos de CRUD da Entidade.
    /// </summary>
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MKWContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> GetByUserId(int userId) => await _dbSet.Where(x => x.Person.UserId == userId && x.Active).ToListAsync();
    }
}
