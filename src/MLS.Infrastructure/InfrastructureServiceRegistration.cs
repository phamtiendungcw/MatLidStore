using Microsoft.Extensions.DependencyInjection;
using MLS.Application.Contracts.Logging;
using MLS.Infrastructure.Logging;

namespace MLS.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}