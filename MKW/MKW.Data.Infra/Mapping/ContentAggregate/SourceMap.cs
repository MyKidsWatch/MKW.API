using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Data.Context.Mapping.ContentAggregate
{
    public class SourceMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Source>()
                .ToTable("TB_MKW_SOURCE");

            modelBuilder.Entity<Source>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Source>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Source>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Source>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<Source>()
                .Property(x => x.Url)
                .HasColumnName("URL");

            modelBuilder.Entity<Source>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Source>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Source>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Source>()
                .HasMany(x => x.ContentCategories)
                .WithOne(x => x.Source)
                .HasForeignKey(x => x.SourceId);
        }
    }
}
