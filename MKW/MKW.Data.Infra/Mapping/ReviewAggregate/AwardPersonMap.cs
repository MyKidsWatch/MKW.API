using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    public class AwardPersonMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AwardPerson>()
                .ToTable("TB_RVW_AWARD_PERSON");

            modelBuilder.Entity<AwardPerson>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AwardPerson>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<AwardPerson>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<AwardPerson>()
                .Property(x => x.AwardId)
                .HasColumnName("AWARD_ID");

            modelBuilder.Entity<AwardPerson>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID");

            modelBuilder.Entity<AwardPerson>()
                .Property(x => x.ReviewId)
                .HasColumnName("REVIEW_ID");

            modelBuilder.Entity<AwardPerson>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<AwardPerson>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<AwardPerson>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<AwardPerson>()
                .HasOne(x => x.Person)
                .WithMany(x => x.AwardsGiven)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AwardPerson>()
                .HasOne(x => x.Award)
                .WithMany(x => x.AwardPerson)
                .HasForeignKey(x => x.AwardId);

            modelBuilder.Entity<AwardPerson>()
                .HasOne(x => x.Review)
                .WithMany(x => x.Awards)
                .HasForeignKey(x => x.ReviewId);
        }
    }
}
