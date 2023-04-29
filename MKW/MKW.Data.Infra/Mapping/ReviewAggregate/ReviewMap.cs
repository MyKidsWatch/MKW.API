using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    /// <summary>
    /// Mapeia a entidade Review em relação à tabela da Base de Dados
    /// </summary>
    public class ReviewMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .ToTable("TB_RVW_REVIEW");

            modelBuilder.Entity<Review>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Review>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Review>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Review>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID");

            modelBuilder.Entity<Review>()
                .Property(x => x.ContentId)
                .HasColumnName("CONTENT_ID");

            modelBuilder.Entity<Review>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Review>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Review>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Review>()
                .HasMany(x => x.ReviewDetails)
                .WithOne(x => x.Review)
                .HasForeignKey(x => x.ReviewId);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.Content)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ContentId);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Review>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Review)
                .HasForeignKey(x => x.ReviewId);

            modelBuilder.Entity<Review>()
                .HasMany(x => x.Awards)
                .WithOne(x => x.Review)
                .HasForeignKey(x => x.ReviewId);
        }
    }
}
