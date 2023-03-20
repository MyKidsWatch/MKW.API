using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    /// <summary>
    /// Mapeia a entidade Gender em relação à tabela da Base de Dados
    /// </summary>
    public class GenderMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .ToTable("TB_USR_GENDER");

            modelBuilder.Entity<Gender>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Gender>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Gender>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Gender>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<Gender>()
                .Property(x => x.IsBinary)
                .HasColumnName("IS_BINARY");

            modelBuilder.Entity<Gender>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Gender>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Gender>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Gender>()
                .HasMany(x => x.Children)
                .WithOne(x => x.Gender)
                .HasForeignKey(x => x.GenderId);

            modelBuilder.Entity<Gender>()
                .HasMany(x => x.People)
                .WithOne(x => x.Gender)
                .HasForeignKey(x => x.GenderId);
        }
    }
}
