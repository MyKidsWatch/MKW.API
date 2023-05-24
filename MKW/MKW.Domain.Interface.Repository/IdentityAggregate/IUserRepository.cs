using MKW.Domain.Entities.IdentityAggregate;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IUserRepository : IUserBaseRepository<ApplicationUser>
    {
    }
}
