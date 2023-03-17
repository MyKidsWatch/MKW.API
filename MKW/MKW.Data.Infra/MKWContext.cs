using Microsoft.EntityFrameworkCore;

namespace MKW.Data.Infra
{
    public class MKWContext : DbContext
    {
        public MKWContext(DbContextOptions<MKWContext> options) : base(options)
        {

        }
    }
}
