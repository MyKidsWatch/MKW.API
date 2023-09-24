using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Data.Context.Mapping.ContentAggregate
{
    /// <summary>
    /// Mapeia a entidade PlatformCategory em relação à tabela da Base de Dados
    /// </summary>
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

            var filme = new PlatformCategory()
            {
                Id = 1,
                PlatformId = 1,
                Name = "Filme",
                Active = true,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                AlterDate = null
            };

            var canal = new PlatformCategory()
            {
                Id = 2,
                PlatformId = 2,
                Name = "Filme",
                Active = true,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                AlterDate = null
            };

            var perfil = new PlatformCategory()
            {
                Id = 3,
                PlatformId = 3,
                Name = "Perfil",
                Active = true,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                AlterDate = null
            };

            modelBuilder.Entity<PlatformCategory>().HasData(filme);
            modelBuilder.Entity<PlatformCategory>().HasData(canal);
            modelBuilder.Entity<PlatformCategory>().HasData(perfil);

        }
    }
}
