﻿using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context.Mapping.UserAggregate
{
    public class OperationTypeMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OperationType>()
                .ToTable("TB_USR_OPERATION_TYPE");

            modelBuilder.Entity<OperationType>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OperationType>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<OperationType>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<OperationType>()
                .Property(x => x.Credit)
                .HasColumnName("CREDIT");

            modelBuilder.Entity<OperationType>()
                .Property(x => x.Type)
                .HasColumnName("TYPE");

            modelBuilder.Entity<OperationType>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<OperationType>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<OperationType>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<OperationType>()
                .HasMany(x => x.Operations)
                .WithOne(x => x.OperationType)
                .HasForeignKey(x => x.OperationTypeId);

            var purchase = new OperationType()
            {
                Id = 1,
                UUID = Guid.NewGuid(),
                Type = "Purchase",
                Credit = false,
                Active = true,
                CreateDate = DateTime.Now,
                AlterDate = null
            };

            var earn = new OperationType()
            {
                Id = 2,
                UUID = Guid.NewGuid(),
                Type = "Earn",
                Credit = true,
                Active = true,
                CreateDate = DateTime.Now,
                AlterDate = null
            };

            modelBuilder.Entity<OperationType>().HasData(purchase);
            modelBuilder.Entity<OperationType>().HasData(earn);
        }
    }
}
