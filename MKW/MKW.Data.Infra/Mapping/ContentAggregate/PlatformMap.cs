using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Data.Context.Mapping.ContentAggregate
{
    /// <summary>
    /// Mapeia a entidade Platform em relação à tabela da Base de Dados
    /// </summary>
    public class PlatformMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .ToTable("TB_MKW_PLATFORM");

            modelBuilder.Entity<Platform>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Platform>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Platform>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Platform>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<Platform>()
                .Property(x => x.Url)
                .HasColumnName("URL");

            modelBuilder.Entity<Platform>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Platform>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Platform>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Platform>()
                .HasMany(x => x.PlatformCategories)
                .WithOne(x => x.Platform)
                .HasForeignKey(x => x.PlatformId);
        }
    }
}
