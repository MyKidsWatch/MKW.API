using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    /// <summary>
    /// Mapeia a entidade ReviewDetails em relação à tabela da Base de Dados
    /// </summary>
    public class ReviewDetailsMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReviewDetails>()
                .ToTable("TB_RVW_REVIEW_DETAILS");

            modelBuilder.Entity<ReviewDetails>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.ReviewId)
                .HasColumnName("POST_ID");

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.Title)
                .HasColumnName("TITLE");

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.Text)
                .HasColumnName("TEXT");

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.Stars)
                .HasColumnName("STARS");

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<ReviewDetails>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<ReviewDetails>()
                .HasOne(x => x.Review)
                .WithMany(x => x.ReviewDetails)
                .HasForeignKey(x => x.ReviewId);
        }
    }
}
