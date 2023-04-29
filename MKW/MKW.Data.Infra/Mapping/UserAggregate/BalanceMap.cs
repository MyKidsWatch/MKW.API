using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    public class BalanceMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>()
                .ToTable("TB_USR_BALANCE");

            modelBuilder.Entity<Balance>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Balance>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Balance>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Balance>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID");

            modelBuilder.Entity<Balance>()
                .Property(x => x.StarCoins)
                .HasColumnName("STAR_COINS");

            modelBuilder.Entity<Balance>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Balance>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Balance>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Balance>()
                .HasOne(x => x.Person)
                .WithOne(x => x.Balance)
                .HasForeignKey<Balance>(x => x.PersonId);

            modelBuilder.Entity<Balance>()
                .HasMany(x => x.Transactions)
                .WithOne(x => x.Balance)
                .HasForeignKey(x => x.BalanceId);
        }
    }
}
