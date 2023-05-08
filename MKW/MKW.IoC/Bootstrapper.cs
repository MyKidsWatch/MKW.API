using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MKW.IoC.Modules;

namespace MKW.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            MiddlewareModule.InjectDependencies(services);
            RepositoryModule.InjectDependencies(services);
            ServiceModule.InjectDependencies(services);
            IdentityModule.AddAuthentication(services, configuration);
            EmailModule.AddEmailConfiguration(services, configuration);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
    }
}
