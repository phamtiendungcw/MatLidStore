using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;

namespace MLS.Persistence
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MatLidStoreDatabaseContext>(options => options.UseOracle(configuration.GetConnectionString("MatLidConnectionString")));

            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<MatLidStoreDatabaseContext>()
                    .AddDefaultTokenProviders();

            return services;
        }
    }
}