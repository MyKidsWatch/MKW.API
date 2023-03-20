using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.PremiumAggregate;

namespace MKW.Data.Context.Mapping.PremiumAggregate
{
    /// <summary>
    /// Mapeia a entidade PremiumPerson em relação à tabela da Base de Dados
    /// </summary>
    public class PremiumPersonMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PremiumPerson>()
                .ToTable("TB_PRM_PREMIUM_PERSON");

            modelBuilder.Entity<PremiumPerson>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.TierPlanId)
                .HasColumnName("TIER_PLAN_ID");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.StartDate)
                .HasColumnName("START_DATE");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.EndDate)
                .HasColumnName("END_DATE");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.AutoRenewal)
                .HasColumnName("AUTORENEWAL");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<PremiumPerson>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<PremiumPerson>()
                .HasOne(x => x.Person)
                .WithMany(x => x.PremiumPerson)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<PremiumPerson>()
                .HasOne(x => x.TierPlan)
                .WithMany(x => x.PremiumPerson)
                .HasForeignKey(x => x.TierPlanId);
        }
    }
}
