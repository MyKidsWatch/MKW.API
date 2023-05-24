using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    public class OperationMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                .ToTable("TB_USR_OPERATION");

            modelBuilder.Entity<Operation>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Operation>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Operation>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Operation>()
                .Property(x => x.PersonId)
                .HasColumnName("PERSON_ID");

            modelBuilder.Entity<Operation>()
                .Property(x => x.OperationTypeId)
                .HasColumnName("OPERATION_TYPE_ID");

            modelBuilder.Entity<Operation>()
                .Property(x => x.Coins)
                .HasColumnName("COINS");

            modelBuilder.Entity<Operation>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Operation>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Operation>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Operation>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Operations)
                .HasForeignKey(x => x.PersonId);

            modelBuilder.Entity<Operation>()
                .HasOne(x => x.OperationType)
                .WithMany(x => x.Operations)
                .HasForeignKey(x => x.OperationTypeId);
        }
    }
}
