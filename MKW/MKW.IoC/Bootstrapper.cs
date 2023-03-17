using Microsoft.Extensions.DependencyInjection;
using MKW.IoC.Modules;

namespace MKW.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            MiddlewareModule.InjectDependencies(builder);
            RepositoryModule.InjectDependencies(builder);
            ServiceModule.InjectDependencies(builder);
        }
    }
}
