using Microsoft.Extensions.DependencyInjection;
using PCACalcula.Domain.Interfaces;
using PCACalcula.Domain.Services;

namespace PCACalcula.ApiStartup
{
    public static class ScopedServicesConfig
    {
        public static void ConfigureScopedServices(this IServiceCollection services)
        {
            ResolveAppServices(services);
        }

        private static void ResolveAppServices(this IServiceCollection services)
        {
            services.AddTransient<ICalculaJurosService, CalculaJurosService>();
            services.AddTransient<IGitHubService, GitHubService>();
            services.AddTransient<IServiceBase, ServiceBase>();
        }
    }
}
