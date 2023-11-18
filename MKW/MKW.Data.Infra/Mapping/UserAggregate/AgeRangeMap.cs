using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    /// <summary>
    /// Mapeia a entidade AgeRange em relação à tabela da Base de Dados
    /// </summary>
    public class AgeRangeMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeRange>()
                .ToTable("TB_USR_AGE_RANGE");

            modelBuilder.Entity<AgeRange>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.InitialAge)
                .HasColumnName("INITIAL_AGE");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.FinalAge)
                .HasColumnName("FINAL_AGE");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<AgeRange>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<AgeRange>()
                .HasMany(x => x.Children)
                .WithOne(x => x.AgeRange)
                .HasForeignKey(x => x.AgeRangeId);

            var ageRange1 = new AgeRange()
            {
                Id = 1,
                InitialAge = 0,
                FinalAge = 2,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Active = true
            };

            var ageRange2 = new AgeRange()
            {
                Id = 2,
                InitialAge = 3,
                FinalAge = 5,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Active = true
            };

            var ageRange3 = new AgeRange()
            {
                Id = 3,
                InitialAge = 6,
                FinalAge = 8,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Active = true
            };

            var ageRange4 = new AgeRange()
            {
                Id = 4,
                InitialAge = 9,
                FinalAge = 11,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Active = true
            };

            var ageRange5 = new AgeRange()
            {
                Id = 5,
                InitialAge = 12,
                FinalAge = 14,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Active = true
            };

            var ageRange6 = new AgeRange()
            {
                Id = 6,
                InitialAge = 15,
                FinalAge = 17,
                UUID = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Active = true
            };

            modelBuilder.Entity<AgeRange>().HasData(ageRange1);
            modelBuilder.Entity<AgeRange>().HasData(ageRange2);
            modelBuilder.Entity<AgeRange>().HasData(ageRange3);
            modelBuilder.Entity<AgeRange>().HasData(ageRange4);
            modelBuilder.Entity<AgeRange>().HasData(ageRange5);
            modelBuilder.Entity<AgeRange>().HasData(ageRange6);
        }
    }
}
