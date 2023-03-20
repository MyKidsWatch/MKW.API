using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Data.Context.Mapping.ContentAggregate
{
    public class PlatformCategoryMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformCategory>()
                .ToTable("TB_MKW_PLATFORM_CATEGORY");

            modelBuilder.Entity<PlatformCategory>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PlatformCategory>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<PlatformCategory>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<PlatformCategory>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<PlatformCategory>()
                .Property(x => x.PlatformId)
                .HasColumnName("PLATFORM_ID");

            modelBuilder.Entity<PlatformCategory>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<PlatformCategory>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<PlatformCategory>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<PlatformCategory>()
                .HasOne(x => x.Platform)
                .WithMany(x => x.PlatformCategories)
                .HasForeignKey(x => x.PlatformId);

            modelBuilder.Entity<PlatformCategory>()
                .HasMany(x => x.Contents)
                .WithOne(x => x.PlatformCategory)
                .HasForeignKey(x => x.PlatformCategoryId);
        }
    }
}
