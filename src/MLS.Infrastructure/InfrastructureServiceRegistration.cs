using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLS.Application.Contracts.Email;
using MLS.Application.Contracts.Logging;
using MLS.Application.Models.Email;
using MLS.Infrastructure.EmailService;
using MLS.Infrastructure.Logging;

namespace MLS.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}