using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    /// <summary>
    /// Mapeia a entidade PostDetails em relação à tabela da Base de Dados
    /// </summary>
    public class PostDetailsMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostDetails>()
                .ToTable("TB_RVW_POST_DETAILS");

            modelBuilder.Entity<PostDetails>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PostDetails>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<PostDetails>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<PostDetails>()
                .Property(x => x.PostId)
                .HasColumnName("POST_ID");

            modelBuilder.Entity<PostDetails>()
                .Property(x => x.Title)
                .HasColumnName("TITLE");

            modelBuilder.Entity<PostDetails>()
                .Property(x => x.Text)
                .HasColumnName("TEXT");

            modelBuilder.Entity<PostDetails>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<PostDetails>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<PostDetails>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<PostDetails>()
                .HasOne(x => x.Post)
                .WithMany(x => x.PostDetails)
                .HasForeignKey(x => x.PostId);
        }
    }
}
