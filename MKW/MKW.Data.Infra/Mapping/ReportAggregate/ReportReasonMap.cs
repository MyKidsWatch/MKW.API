using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.ReportAggregate;

namespace MKW.Data.Context.Mapping.ReportAggregate
{
    public class ReportReasonMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportReason>()
                .ToTable("TB_RPR_REASON");

            modelBuilder.Entity<ReportReason>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ReportReason>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<ReportReason>()
                .Property(x => x.UUID)
                .HasColumnName("UUID");

            modelBuilder.Entity<ReportReason>()
                .Property(x => x.Title)
                .HasColumnName("TITLE");

            modelBuilder.Entity<ReportReason>()
                .Property(x => x.Description)
                .HasColumnName("DESCRIPTION");

            modelBuilder.Entity<ReportReason>()
                .Property(x => x.CreateDate)
                .HasColumnName("CREATE_DATE");

            modelBuilder.Entity<ReportReason>()
                .Property(x => x.AlterDate)
                .HasColumnName("ALTER_DATE");

            modelBuilder.Entity<ReportReason>()
                .Property(x => x.Active)
                .HasColumnName("ACTIVE");

            modelBuilder.Entity<ReportReason>()
                .HasMany(x => x.Reports)
                .WithOne(x => x.Reason)
                .HasForeignKey(x => x.ReasonId);

            var reasonHateSpeech = new ReportReason()
            {
                Id = 1,
                UUID = Guid.NewGuid(),
                Title = "Hate Speech",
                Description = "Abusive or threatening speech or writing that expresses prejudice on the basis of ethnicity, religion, sexual orientation, or similar grounds.",
                CreateDate = DateTime.Now,
                AlterDate = null,
                Active = true
            };

            var reasonHarassment = new ReportReason()
            {
                Id = 2,
                UUID = Guid.NewGuid(),
                Title = "Harassment",
                Description = "Aggressive pressure or intimidation against an individual or group.",
                CreateDate = DateTime.Now,
                AlterDate = null,
                Active = true
            };

            var reasonSex = new ReportReason()
            {
                Id = 3,
                UUID = Guid.NewGuid(),
                Title = "Sexual Content",
                Description = "Material depicting sexual behavior. The sexual behavior involved may be explicit, implicit sexual behavior such as flirting, or include sexual language and euphemisms.",
                CreateDate = DateTime.Now,
                AlterDate = null,
                Active = true
            };

            var reasonOthers = new ReportReason()
            {
                Id = 4,
                UUID = Guid.NewGuid(),
                Title = "Others",
                Description = "Other reasons. Please provide more information.",
                CreateDate = DateTime.Now,
                AlterDate = null,
                Active = true
            };

            modelBuilder.Entity<ReportReason>().HasData(reasonHateSpeech);
            modelBuilder.Entity<ReportReason>().HasData(reasonHarassment);
            modelBuilder.Entity<ReportReason>().HasData(reasonSex);
            modelBuilder.Entity<ReportReason>().HasData(reasonOthers);
        }
    }
}
