using Microsoft.Extensions.DependencyInjection;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Services.AppServices;
using MKW.Services.BaseServices;
using MKW.Services.ProfileService;

namespace MKW.IoC.Modules
{
    public static class ServiceModule
    {
        public static void InjectDependencies(IServiceCollection builder)
        {
            #region AppServices
            builder.AddTransient<IAgeRangeService, AgeRangeService>();
            builder.AddTransient<IAwardService, AwardService>();
            builder.AddTransient<IChildService, ChildService>();
            builder.AddTransient<ICommentService, CommentService>();
            builder.AddTransient<IContentService, ContentService>();
            builder.AddTransient<IGenderService, GenderService>();
            builder.AddTransient<IOperationService, OperationService>();
            builder.AddTransient<IPersonService, PersonService>();
            builder.AddTransient<IPlatformService, PlatformService>();
            builder.AddTransient<IProfileService, ProfileService>();
            builder.AddTransient<IReportService, ReportService>();
            builder.AddTransient<IReviewService, ReviewService>();
            #endregion
            #region BaseServices
            builder.AddTransient<IAlgorithmService, AlgorithmService>();
            builder.AddTransient<IPaymentService, PaymentService>();
            builder.AddTransient<ITmdbService, TmdbService>();
            #endregion
        }
    }
}
