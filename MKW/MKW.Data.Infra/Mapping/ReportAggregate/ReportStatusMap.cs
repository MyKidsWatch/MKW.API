using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReportAggregate;

namespace MKW.Data.Context.Mapping.ReportAggregate
{
    public class ReportStatusMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportStatus>()
                .ToTable("TB_RPR_STATUS");

            modelBuilder.Entity<ReportStatus>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ReportStatus>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<ReportStatus>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<ReportStatus>()
                .Property(x => x.Name)
                .HasColumnName("NAME");

            modelBuilder.Entity<ReportStatus>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<ReportStatus>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<ReportStatus>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<ReportStatus>()
                .HasMany(x => x.Reports)
                .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId);

            var statusInicial = new ReportStatus()
            {
                Id = 1,
                UUID = Guid.NewGuid(),
                Name = "Análise Pendente",
                CreateDate = DateTime.Now,
                AlterDate = null,
                Active = true
            };

            var statusAnalisado = new ReportStatus()
            {
                Id = 2,
                UUID = Guid.NewGuid(),
                Name = "Analisado",
                CreateDate = DateTime.Now,
                AlterDate = null,
                Active = true
            };

            var statusDescartado = new ReportStatus()
            {
                Id = 3,
                UUID = Guid.NewGuid(),
                Name = "Descartado",
                CreateDate = DateTime.Now,
                AlterDate = null,
                Active = true
            };

            modelBuilder.Entity<ReportStatus>().HasData(statusInicial);
            modelBuilder.Entity<ReportStatus>().HasData(statusAnalisado);
            modelBuilder.Entity<ReportStatus>().HasData(statusDescartado);
        }
    }
}
