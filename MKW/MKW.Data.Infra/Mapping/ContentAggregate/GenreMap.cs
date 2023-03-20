using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Data.Context.Mapping.ContentAggregate
{
    public class GenreMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .ToTable("TB_MKW_GENRE");

            modelBuilder.Entity<Genre>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Genre>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Genre>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Genre>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<Genre>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Genre>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Genre>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Genre>()
                .HasMany(x => x.ContentGenre)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId);
        }
    }
}
