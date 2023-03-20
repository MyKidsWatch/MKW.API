using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Data.Context.Mapping.ContentAggregate
{
    public class ContentMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>()
                .ToTable("TB_MKW_CONTENT");

            modelBuilder.Entity<Content>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Content>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Content>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Content>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<Content>()
                .Property(x => x.PlatformCategoryId)
                .HasColumnName("CATEGORY_ID");

            modelBuilder.Entity<Content>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Content>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Content>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Content>()
                .HasOne(x => x.PlatformCategory)
                .WithMany(x => x.Contents)
                .HasForeignKey(x => x.PlatformCategoryId);

            modelBuilder.Entity<Content>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.Content)
                .HasForeignKey(x => x.ContentId);
        }
    }
}
