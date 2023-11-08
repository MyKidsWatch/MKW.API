using Microsoft.Extensions.DependencyInjection;
using MKW.Domain.Interface.Services.Plugins;
using MKW.Services.Plugin.ContentSources;

namespace MKW.IoC.Modules
{
    public static class PluginModule
    {
        public static void InjectDependencies(IServiceCollection builder)
        {
            var platformAssembly = typeof(TMDbSource).Assembly;

            var platformPlugins = platformAssembly
                .GetTypes()
                .Where(x => typeof(IExternalSource).IsAssignableFrom(x) && !x.IsInterface)
                .ToDictionary(x =>
                                x.Name.Replace("Source", ""),
                                x => ActivatorUtilities.CreateInstance(builder.BuildServiceProvider(), x) as IExternalSource)
                as IDictionary<string, IExternalSource>;

            builder.AddTransient(x => platformPlugins);
        }
    }
}
