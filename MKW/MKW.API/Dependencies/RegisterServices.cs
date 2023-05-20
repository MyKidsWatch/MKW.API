using MKW.IoC;

namespace MKW.API.Dependencies
{
    public static class RegisterServices
    {
        public static IServiceCollection StartRegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            Bootstrapper.RegisterServices(services, configuration);

            return services;
        }
    }
}
