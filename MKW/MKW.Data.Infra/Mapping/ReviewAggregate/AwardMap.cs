using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    public class AwardMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>()
                .ToTable("TB_RVW_AWARD");

            modelBuilder.Entity<Award>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Award>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Award>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Award>()
                .Property(x => x.Price)
                .HasColumnName("PRICE");

            modelBuilder.Entity<Award>()
                .Property(x => x.Value)
                .HasColumnName("VALUE");

            modelBuilder.Entity<Award>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Award>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Award>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Award>()
                .HasMany(x => x.AwardPerson)
                .WithOne(x => x.Award)
                .HasForeignKey(x => x.AwardId);
        }
    }
}
