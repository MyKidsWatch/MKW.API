using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context.Mapping.ReviewAggregate
{
    public class AwardMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>()
                .ToTable("TB_RVW_AWARD");

            modelBuilder.Entity<Award>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Award>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Award>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<Award>()
                .Property(x => x.Price)
                .HasColumnName("PRICE");

            modelBuilder.Entity<Award>()
                .Property(x => x.Value)
                .HasColumnName("VALUE");

            modelBuilder.Entity<Award>()
                .Property(x => x.StripeId)
                .HasColumnName("STRIPE_ID");

            modelBuilder.Entity<Award>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<Award>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<Award>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<Award>()
                .HasMany(x => x.AwardPerson)
                .WithOne(x => x.Award)
                .HasForeignKey(x => x.AwardId);

            var golden = new Award()
            {
                Id = 1,
                UUID = Guid.NewGuid(),
                Name = "Gold",
                Price = 100,
                Value = 50,
                StripeId = "prod_OwcYJeSRGJKd73",
                CreateDate = DateTime.Now,
                Active = true,
            };

            var silver = new Award()
            {
                Id = 2,
                UUID = Guid.NewGuid(),
                Name = "Silver",
                Price = 50,
                Value = 25,
                StripeId = "prod_OwchFQzaZ0N7Kz",
                CreateDate = DateTime.Now,
                Active = true,
            };

            var bronze = new Award()
            {
                Id = 3,
                UUID = Guid.NewGuid(),
                Name = "Bronze",
                Price = 20,
                Value = 10,
                StripeId = "prod_Owcj9UpEVnpBgi",
                CreateDate = DateTime.Now,
                Active = true,
            };

            modelBuilder.Entity<Award>().HasData(golden);
            modelBuilder.Entity<Award>().HasData(silver);
            modelBuilder.Entity<Award>().HasData(bronze);
        }
    }
}
