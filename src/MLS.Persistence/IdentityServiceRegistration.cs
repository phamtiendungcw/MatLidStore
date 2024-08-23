using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MLS.Application.Contracts.Token;
using MLS.Domain.Entities;
using MLS.Persistence.Auth;
using MLS.Persistence.DatabaseContext;
using System.Text;

namespace MLS.Persistence;

public static class IdentityServiceRegistration
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MatLidStoreDatabaseContext>(options => { options.UseOracle(configuration.GetConnectionString("MatLidConnectionString")); });
        services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MatLidStoreDatabaseContext>().AddDefaultTokenProviders();
        services.AddScoped<ITokenService, TokenService>();
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtBearerOptions =>
            {
                var tokenKey = configuration["TokenKey"] ?? throw new InvalidOperationException("TokenKey not found.");
                jwtBearerOptions.RequireHttpsMetadata = false;
                jwtBearerOptions.SaveToken = true;
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
}