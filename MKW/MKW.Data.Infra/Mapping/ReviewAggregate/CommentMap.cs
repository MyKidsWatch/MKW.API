using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    public class CommentMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .ToTable("TB_RVW_COMMENT");

            modelBuilder.Entity<Comment>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Comment>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Comment>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Comment>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID");

            modelBuilder.Entity<Comment>()
                .Property(x => x.PostId)
                .HasColumnName("POST_ID");

            modelBuilder.Entity<Comment>()
                .Property(x => x.ParentComentId)
                .HasColumnName("PARENT_COMMENT_ID");

            modelBuilder.Entity<Comment>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Comment>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Comment>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId);

            modelBuilder.Entity<Comment>()
                .HasMany(x => x.CommentDetails)
                .WithOne(x => x.Comment)
                .HasForeignKey(x => x.CommentId);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Comment>()
                .HasMany(x => x.Answers)
                .WithOne(x => x.ParentComment)
                .HasForeignKey(x => x.ParentComentId);
        }
    }
}
