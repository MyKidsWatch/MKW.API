using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    public class TransactionMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .ToTable("TB_USR_TRANSACTION");

            modelBuilder.Entity<Transaction>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.BalanceId)
                .HasColumnName("BALANCE_ID");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.CurrentBalance)
                .HasColumnName("CURRENT_BALANCE");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.NewBalance)
                .HasColumnName("NEW_BALANCE");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Operation)
                .HasColumnName("OPERATION");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Value)
                .HasColumnName("VALUE");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Transaction>()
                .HasOne(x => x.Balance)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.BalanceId);
        }
    }
}
