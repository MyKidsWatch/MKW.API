using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using MKW.Data.Context.Mapping.ContentAggregate;
using MKW.Data.Context.Mapping.IdentityAggregate;
using MKW.Data.Context.Mapping.PremiumAggregate;
using MKW.Data.Context.Mapping.ReportAggregate;
using MKW.Data.Context.Mapping.ReviewAggregate;
using MKW.Data.Context.Mapping.UserAggregate;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.PremiumAggregate;
using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;

namespace MKW.Data.Context
{
    /// <summary>
    /// Contexto da Base de Dados do MyKidsWatch. Contém propriedades de acesso às Tabelas relacionadas às Entidades do Sistema.
    /// </summary>
    public class MKWContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        private readonly ApplicationIdentityOptions _applicationIdentityOptions;

        public MKWContext(DbContextOptions<MKWContext> options, IOptions<ApplicationIdentityOptions> applicationIdentityOptions) : base(options)
        {
            _applicationIdentityOptions = applicationIdentityOptions.Value;
        }

        public DbSet<Award> Award { get; set; }
        public DbSet<AwardPerson> AwardPerson { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentDetails> CommentDetails { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<ContentGenre> ContentGenre { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Operation> Operation { get; set; }
        public DbSet<OperationType> OperationType { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<PlatformCategory> PlatformCategory { get; set; }
        public DbSet<PremiumPerson> PremiumPerson { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<ReportReason> ReportReason { get; set; }
        public DbSet<ReportStatus> ReportStatus { get; set; }
        public DbSet<Review> Post { get; set; }
        public DbSet<ReviewDetails> PostDetails { get; set; }
        public DbSet<Tier> Tier { get; set; }
        public DbSet<TierPlan> TierPlan { get; set; }
        public DbSet<Timespan> Timespan { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            InitializeIdentityMap.Map(modelBuilder, _applicationIdentityOptions);
            AgeRangeMap.Map(modelBuilder);
            AwardMap.Map(modelBuilder);
            AwardPersonMap.Map(modelBuilder);
            CommentDetailsMap.Map(modelBuilder);
            CommentMap.Map(modelBuilder);
            ContentGenreMap.Map(modelBuilder);
            ContentMap.Map(modelBuilder);
            GenderMap.Map(modelBuilder);
            GenreMap.Map(modelBuilder);
            OperationMap.Map(modelBuilder);
            OperationTypeMap.Map(modelBuilder);
            PersonChildMap.Map(modelBuilder);
            PersonMap.Map(modelBuilder);
            PlatformCategoryMap.Map(modelBuilder);
            PlatformMap.Map(modelBuilder);
            PremiumPersonMap.Map(modelBuilder);
            ReportMap.Map(modelBuilder);
            ReportReasonMap.Map(modelBuilder);
            ReportStatusMap.Map(modelBuilder);
            ReviewDetailsMap.Map(modelBuilder);
            ReviewMap.Map(modelBuilder);
            TierMap.Map(modelBuilder);
            TierPlanMap.Map(modelBuilder);
            TimespanMap.Map(modelBuilder);
            UserTokenMap.Map(modelBuilder);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }
    }
}
