﻿using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MKW.IoC.Modules;

namespace MKW.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            MiddlewareModule.InjectDependencies(services);
            RepositoryModule.InjectDependencies(services);
            ServiceModule.InjectDependencies(services);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
    }
}
