using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;
using System.Linq.Expressions;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    /// <summary>
    /// Mapeia a entidade Person em relação à tabela da Base de Dados
    /// </summary>
    public class PersonMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .ToTable("TB_USR_PERSON");

            modelBuilder.Entity<Person>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Person>()
                .Property(x => x.Id)
                .HasColumnName("ID");
            
            modelBuilder.Entity<Person>()
                .Property(x => x.UserId)
                .HasColumnName("USER_ID");

            modelBuilder.Entity<Person>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Person>()
                .Property(x => x.GenderId)
                .HasColumnName("GENDER_ID");

            modelBuilder.Entity<Person>()
                .Property(x => x.ImageURL)
                .HasColumnName("IMAGE_URL");

            modelBuilder.Entity<Person>()
                .Property(x => x.BirthDate)
                .HasColumnName("BIRTHDATE")
                .HasColumnType("date");

            modelBuilder.Entity<Person>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Person>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Person>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Person>()
                .HasOne(x => x.Gender)
                .WithMany(x => x.People)
                .HasForeignKey(x => x.GenderId);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Children)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.PremiumPerson)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Reviews)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Comments)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Person>()
                .HasOne(x => x.Balance)
                .WithOne(x => x.Person)
                .HasForeignKey<Balance>(x => x.PersonId);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.AwardsGiven)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);
        }
    }
}
