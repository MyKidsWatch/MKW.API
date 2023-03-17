using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Data.Infra
{
    public class MKWContext : DbContext
    {
        public MKWContext(DbContextOptions<MKWContext> options) : base(options)
        {

        }
    }
}
