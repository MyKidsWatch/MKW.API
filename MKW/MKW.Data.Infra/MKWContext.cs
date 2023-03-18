using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MKW.Data.Infra
{
    public class MKWContext : DbContext
    {
        public MKWContext(DbContextOptions<MKWContext> options) : base(options)
        {

        }

        public IDbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }
    }
}
