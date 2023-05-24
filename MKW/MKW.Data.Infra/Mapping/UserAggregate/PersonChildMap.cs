using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    /// <summary>
    /// Mapeia a entidade PersonChild em relação à tabela da Base de Dados
    /// </summary>
    public class PersonChildMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonChild>()
                .ToTable("TB_USR_PERSON_CHILD");

            modelBuilder.Entity<PersonChild>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PersonChild>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<PersonChild>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<PersonChild>()
                .Property(x => x.AgeRangeId)
                .HasColumnName("AGE_RANGE_ID");

            modelBuilder.Entity<PersonChild>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID");

            modelBuilder.Entity<PersonChild>()
                .Property(x => x.GenderId)
                .HasColumnName("GENDER_ID");

            modelBuilder.Entity<PersonChild>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<PersonChild>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<PersonChild>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<PersonChild>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonChild>()
                .HasOne(x => x.Gender)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.GenderId);

            modelBuilder.Entity<PersonChild>()
                .HasOne(x => x.AgeRange)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.AgeRangeId);
        }
    }
}
