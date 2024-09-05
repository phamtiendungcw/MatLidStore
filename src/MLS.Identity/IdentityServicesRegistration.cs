using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MLS.Application.Contracts.Identity;
using MLS.Application.Models.Identity;
using MLS.Identity.DatabaseContext;
using MLS.Identity.Models;
using MLS.Identity.Services;
using System.Text;

namespace MLS.Identity;

public static class IdentityServicesRegistration
{
    public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<MatLidStoreManagementIdentityDbContext>(options => options.UseOracle(configuration.GetConnectionString("MatLidConnectionString")));

        services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MatLidStoreManagementIdentityDbContext>().AddDefaultTokenProviders();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserService, UserService>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var tokenKey = configuration["JwtSettings:Key"] ?? throw new InvalidOperationException("JwtSettings:Key not found.");
            var tokenIssuer = configuration["JwtSettings:Issuer"] ?? throw new InvalidOperationException("JwtSettings:Issuer not found.");
            var tokenAudience = configuration["JwtSettings:Audience"] ?? throw new InvalidOperationException("JwtSettings:Audience not found.");
            o.SaveToken = true;
            o.RequireHttpsMetadata = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = tokenIssuer,
                ValidAudience = tokenAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey))
            };
        });

        return services;
    }
}