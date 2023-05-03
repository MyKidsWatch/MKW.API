using MKW.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IUserRepository : IUserBaseRepository<User>
    {
    }
}
