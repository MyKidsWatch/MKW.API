using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.PremiumAggregate;

namespace MKW.Data.Context.Mapping.PremiumAggregate
{
    /// <summary>
    /// Mapeia a entidade Tier em relação à tabela da Base de Dados
    /// </summary>
    public class TierMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tier>()
                .ToTable("TB_PRM_TIER");

            modelBuilder.Entity<Tier>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Tier>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Tier>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Tier>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<Tier>()
                .Property(x => x.IsPremium)
                .HasColumnName("IS_PREMIUM");

            modelBuilder.Entity<Tier>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Tier>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Tier>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Tier>()
                .HasMany(x => x.TierPlans)
                .WithOne(x => x.Tier)
                .HasForeignKey(x => x.TierId);
        }
    }
}
