using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MKW.Data.Context.Mapping.ContentAggregate;
using MKW.Data.Context.Mapping.PremiumAggregate;
using MKW.Data.Context.Mapping.ReviewAggregate;

namespace MKW.Data.Context
{
    public class MKWContext : DbContext
    {
        public MKWContext(DbContextOptions<MKWContext> options) : base(options)
        {

        }

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
