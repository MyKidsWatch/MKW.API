using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MKW.Data.Context.Mapping.ContentAggregate;
using MKW.Data.Context.Mapping.PremiumAggregate;
using MKW.Data.Context.Mapping.ReviewAggregate;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.PremiumAggregate;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Data.Context
{
    /// <summary>
    /// Contexto da Base de Dados do MyKidsWatch. Contém propriedades de acesso às Tabelas relacionadas às Entidades do Sistema.
    /// </summary>
    public class MKWContext : DbContext
    {
        public MKWContext(DbContextOptions<MKWContext> options) : base(options)
        {

        }

        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentDetails> CommentDetails { get; set; }
        public DbSet<ContentGenre> ContentGenre { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<PlatformCategory> PlatformCategory { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostDetails> PostDetails { get; set; }
        public DbSet<PremiumPerson> PremiumPerson { get; set; }
        public DbSet<Tier> Tier { get; set; }
        public DbSet<TierPlan> TierPlan { get; set; }
        public DbSet<Timespan> Timespan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CommentDetailsMap.Map(modelBuilder);
            CommentMap.Map(modelBuilder);
            ContentGenreMap.Map(modelBuilder);
            ContentMap.Map(modelBuilder);
            GenreMap.Map(modelBuilder);
            PlatformCategoryMap.Map(modelBuilder);
            PlatformMap.Map(modelBuilder);
            PostDetailsMap.Map(modelBuilder);
            PostMap.Map(modelBuilder);
            PremiumPersonMap.Map(modelBuilder);
            TierMap.Map(modelBuilder);
            TierPlanMap.Map(modelBuilder);
            TimespanMap.Map(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Database.BeginTransaction();
        }
    }
}
