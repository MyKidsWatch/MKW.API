﻿using Microsoft.Extensions.DependencyInjection;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.AppServices.Identity;
using MKW.Domain.Interface.Services.AppServices.IdentityService;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Services.AppServices;
using MKW.Services.AppServices.IdentityService;
using MKW.Services.BaseServices;

namespace MKW.IoC.Modules
{
    public static class ServiceModule
    {
        public static void InjectDependencies(IServiceCollection builder)
        {
            #region AppServices
            builder.AddTransient<IPlatformService, PlatformService>();
            builder.AddTransient<IReviewService, ReviewService>();
            builder.AddTransient<IGenderService, GenderService>();
            builder.AddTransient<IPersonService, PersonService>();
            #endregion
            #region BaseServices
            builder.AddTransient<IEmailService, EmailService>();
            builder.AddTransient<ITmdbService, TmdbService>();
            builder.AddTransient<IAlgorithmService, AlgorithmService>();
            #endregion
        }
    }
}
