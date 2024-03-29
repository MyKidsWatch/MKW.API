﻿using Microsoft.Extensions.DependencyInjection;
using MKW.Data.Repository.Base;
using MKW.Data.Repository.ContentAggregate;
using MKW.Data.Repository.IdentityAggregate;
using MKW.Data.Repository.PremiumAggregate;
using MKW.Data.Repository.ReportAggregate;
using MKW.Data.Repository.ReviewAggregate;
using MKW.Data.Repository.UserAggregate;
using MKW.Domain.Interface.Repository.Base;
using MKW.Domain.Interface.Repository.ContentAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Repository.PremiumAggregate;
using MKW.Domain.Interface.Repository.ReportAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Repository.UserAggregate;

namespace MKW.IoC.Modules
{
    public static class RepositoryModule
    {
        public static void InjectDependencies(IServiceCollection builder)
        {
            #region Content Aggregate
            builder.AddTransient<IContentGenreRepository, ContentGenreRepository>();
            builder.AddTransient<IContentRepository, ContentRepository>();
            builder.AddTransient<IGenreRepository, GenreRepository>();
            builder.AddTransient<IPlatformCategoryRepository, PlatformCategoryRepository>();
            builder.AddTransient<IPlatformRepository, PlatformRepository>();
            #endregion
            #region Premium Aggregate
            builder.AddTransient<IPremiumPersonRepository, PremiumPersonRepository>();
            builder.AddTransient<ITierPlanRepository, TierPlanRepository>();
            builder.AddTransient<ITierRepository, TierRepository>();
            builder.AddTransient<ITimespanRepository, TimespanRepository>();
            #endregion
            #region Report Aggregate
            builder.AddTransient<IReportRepository, ReportRepository>();
            builder.AddTransient<IReportReasonRepository, ReportReasonRepository>();
            builder.AddTransient<IReportStatusRepository, ReportStatusRepository>();
            #endregion
            #region Review Aggregate
            builder.AddTransient<IAwardPersonRepository, AwardPersonRepository>();
            builder.AddTransient<IAwardRepository, AwardRepository>();
            builder.AddTransient<ICommentDetailsRepository, CommentDetailsRepository>();
            builder.AddTransient<ICommentRepository, CommentRepository>();
            builder.AddTransient<IReviewDetailsRepository, ReviewDetailsRepository>();
            builder.AddTransient<IReviewRepository, ReviewRepository>();
            #endregion
            #region User Aggregate
            builder.AddTransient<IAgeRangeRepository, AgeRangeRepository>();
            builder.AddTransient<IGenderRepository, GenderRepository>();
            builder.AddTransient<IPersonRepository, PersonRepository>();
            builder.AddTransient<IPersonChildRepository, PersonChildRepository>();
            builder.AddTransient<IOperationRepository, OperationRepository>();
            builder.AddTransient<IOperationTypeRepository, OperationTypeRepository>();
            #endregion
            #region Identity Aggregate
            builder.AddTransient<IUserRepository, UserRepository>();
            builder.AddTransient<IUserTokenRepository, UserTokenRepository>();
            builder.AddTransient<IRoleRepository, RoleRepository>();
            #endregion
            builder.AddTransient<IAlgorithmRepository, AlgorithmRepository>();
        }
    }
}
