using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

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
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Person>()
                .Property(x => x.Username)
                .HasColumnName("USERNAME");

            modelBuilder.Entity<Person>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<Person>()
                .Property(x => x.LastName)
                .HasColumnName("SURNAME");

            modelBuilder.Entity<Person>()
                .Property(x => x.Hash)
                .HasColumnName("HASH");

            modelBuilder.Entity<Person>()
                .Property(x => x.Email)
                .HasColumnName("EMAIL");

            modelBuilder.Entity<Person>()
                .Property(x => x.GenderId)
                .HasColumnName("GENDER_ID");

            modelBuilder.Entity<Person>()
                .Property(x => x.PhoneCountry)
                .HasColumnName("PHONE_COUNTRY");

            modelBuilder.Entity<Person>()
                .Property(x => x.PhoneArea)
                .HasColumnName("PHONE_AREA");

            modelBuilder.Entity<Person>()
                .Property(x => x.PhoneNumber)
                .HasColumnName("PHONE_NUMBER");

            modelBuilder.Entity<Person>()
                .Property(x => x.Password)
                .HasColumnName("PASSWORD");

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
