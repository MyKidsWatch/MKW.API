using Microsoft.Extensions.DependencyInjection;
using MKW.Middleware;

namespace MKW.IoC.Modules
{
    public static class MiddlewareModule
    {
        public static void InjectDependencies(IServiceCollection builder)
        {
            builder.AddTransient<RequestMiddleware>();
        }
    }
}
