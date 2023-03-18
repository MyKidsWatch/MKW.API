using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    public class CommentDetailsMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentDetails>()
                .ToTable("TB_RVW_COMMENT_DETAILS");

            modelBuilder.Entity<CommentDetails>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CommentDetails>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<CommentDetails>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<CommentDetails>()
                .Property(x => x.CommentId)
                .HasColumnName("COMMENT_ID");

            modelBuilder.Entity<CommentDetails>()
                .Property(x => x.Text)
                .HasColumnName("TEXT");

            modelBuilder.Entity<CommentDetails>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<CommentDetails>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<CommentDetails>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<CommentDetails>()
                .HasOne(x => x.Comment)
                .WithMany(x => x.CommentDetails)
                .HasForeignKey(x => x.CommentId);
        }
    }
}
