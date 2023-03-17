using Microsoft.Extensions.DependencyInjection;

namespace MKW.IoC.Modules
{
    public static class RepositoryModule
    {
        public static void InjectDependencies(IServiceCollection builder)
        {
            //builder.AddTransient<IRepository,Repository>();
        }
    }
}
