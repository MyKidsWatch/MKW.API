using Microsoft.Extensions.DependencyInjection;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Services.BaseServices;

namespace MKW.IoC.Modules
{
    public static class ServiceModule
    {
        public static void InjectDependencies(IServiceCollection builder)
        {
            #region AppServices
            #endregion
            #region BaseServices
            builder.AddTransient<IEmailService, EmailService>();
            #endregion
        }
    }
}
