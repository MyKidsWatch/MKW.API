using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    /// <summary>
    /// Mapeia a entidade Post em relação à tabela da Base de Dados
    /// </summary>
    public class PostMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .ToTable("TB_RVW_POST");

            modelBuilder.Entity<Post>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Post>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Post>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Post>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID");

            modelBuilder.Entity<Post>()
                .Property(x => x.ContentId)
                .HasColumnName("CONTENT_ID");

            modelBuilder.Entity<Post>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Post>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Post>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Post>()
                .HasMany(x => x.PostDetails)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.Content)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.ContentId);

            modelBuilder.Entity<Post>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);
        }
    }
}
