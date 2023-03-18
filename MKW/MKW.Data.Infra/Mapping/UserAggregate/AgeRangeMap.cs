using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    public class AgeRangeMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeRange>()
                .ToTable("TB_USR_AGE_RANGE");

            modelBuilder.Entity<AgeRange>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.InitialAge)
                .HasColumnName("INITIAL_AGE");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.FinalAge)
                .HasColumnName("FINAL_AGE");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<AgeRange>()
                .HasMany(x => x.Children)
                .WithOne(x => x.AgeRange)
                .HasForeignKey(x => x.AgeRangeId);
        }
    }
}
