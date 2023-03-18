using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Data.Context.Mapping.ContentAggregate
{
    public class ContentCategoryMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentCategory>()
                .ToTable("TB_MKW_CONTENT_CATEGORY");

            modelBuilder.Entity<ContentCategory>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ContentCategory>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<ContentCategory>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<ContentCategory>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<ContentCategory>()
                .Property(x => x.SourceId)
                .HasColumnName("SOURCE_ID");

            modelBuilder.Entity<ContentCategory>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<ContentCategory>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<ContentCategory>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<ContentCategory>()
                .HasOne(x => x.Source)
                .WithMany(x => x.ContentCategories)
                .HasForeignKey(x => x.SourceId);

            modelBuilder.Entity<ContentCategory>()
                .HasMany(x => x.Contents)
                .WithOne(x => x.ContentCategory)
                .HasForeignKey(x => x.ContentCategoryId);
        }
    }
}
