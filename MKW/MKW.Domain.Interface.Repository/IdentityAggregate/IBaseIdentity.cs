using MKW.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IBaseIdentity<TIdentity> where TIdentity : class
    {
        Task<TIdentity> GetByUUID(Guid uuid);
        Task<TIdentity> GetById(int id);
        Task<IEnumerable<TIdentity>> GetAll();
        Task<IEnumerable<TIdentity>> GetActive();
        Task<TIdentity> Add(TIdentity entity);
        Task<TIdentity> Update(TIdentity entity);
        Task Delete(TIdentity entity);
        Task DeleteById(int id);
    }
}
