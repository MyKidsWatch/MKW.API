using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.PremiumAggregate;

namespace MKW.Data.Context.Mapping.PremiumAggregate
{
    /// <summary>
    /// Mapeia a entidade TierPlan em relação à tabela da Base de Dados
    /// </summary>
    public class TierPlanMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TierPlan>()
                .ToTable("TB_PRM_TIER_PLAN");

            modelBuilder.Entity<TierPlan>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<TierPlan>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<TierPlan>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<TierPlan>()
                .Property(x => x.TierId)
                .HasColumnName("TIER_ID");

            modelBuilder.Entity<TierPlan>()
                .Property(x => x.TimespanId)
                .HasColumnName("TIMESPAN_ID");

            modelBuilder.Entity<TierPlan>()
                .Property(x => x.Price)
                .HasColumnName("PRICE");

            modelBuilder.Entity<TierPlan>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<TierPlan>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<TierPlan>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<TierPlan>()
                .HasOne(x => x.Tier)
                .WithMany(x => x.TierPlans)
                .HasForeignKey(x => x.TierId);

            modelBuilder.Entity<TierPlan>()
                .HasOne(x => x.Timespan)
                .WithMany(x => x.TierPlans)
                .HasForeignKey(x => x.TimespanId);

            modelBuilder.Entity<TierPlan>()
                .HasMany(x => x.PremiumPerson)
                .WithOne(x => x.TierPlan)
                .HasForeignKey(x => x.TierPlanId);
        }
    }
}
