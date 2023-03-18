using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.PremiumAggregate;

namespace MKW.Data.Context.Mapping.PremiumAggregate
{
    public class TimespanMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timespan>()
                .ToTable("TB_PRM_TIMESPAN");

            modelBuilder.Entity<Timespan>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Timespan>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Timespan>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Timespan>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<Timespan>()
                .Property(x => x.Days)
                .HasColumnName("DAYS");

            modelBuilder.Entity<Timespan>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Timespan>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Timespan>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Timespan>()
                .HasMany(x => x.TierPlans)
                .WithOne(x => x.Timespan)
                .HasForeignKey(x => x.TimespanId);
        }
    }
}
