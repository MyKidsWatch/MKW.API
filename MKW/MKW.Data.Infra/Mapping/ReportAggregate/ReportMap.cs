using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReportAggregate;

namespace MKW.Data.Context.Mapping.ReportAggregate
{
    public class ReportMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .ToTable("TB_RPR_REPORT");

            modelBuilder.Entity<Report>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Report>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Report>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Report>()
                .Property(x => x.ReasonId)
                .HasColumnName("REASON_ID");

            modelBuilder.Entity<Report>()
                .Property(x => x.ReviewId)
                .HasColumnName("REVIEW_ID");

            modelBuilder.Entity<Report>()
                .Property(x => x.CommentId)
                .HasColumnName("COMMENT_ID");

            modelBuilder.Entity<Report>()
                .Property(x => x.Details)
                .HasColumnName("DETAILS");

            modelBuilder.Entity<Report>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Report>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Report>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Report>()
                .HasOne(x => x.Comment)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.CommentId)
                .IsRequired(false);

            modelBuilder.Entity<Report>()
                .HasOne(x => x.Review)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.ReviewId)
                .IsRequired(false);

            modelBuilder.Entity<Report>()
                .HasOne(x => x.Reason)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.ReasonId);
        }
    }
}
