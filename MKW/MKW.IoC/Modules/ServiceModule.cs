using Microsoft.Extensions.DependencyInjection;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Services.AppServices;
using MKW.Services.BaseServices;

namespace MKW.IoC.Modules
{
    public static class ServiceModule
    {
        public static void InjectDependencies(IServiceCollection builder)
        {
            #region AppServices
            builder.AddTransient<IPlatformService, PlatformService>();
            #endregion
            #region BaseServices
            builder.AddTransient<IEmailService, EmailService>();
            builder.AddTransient<ITmdbService, TmdbService>();
            #endregion
        }
    }
}
