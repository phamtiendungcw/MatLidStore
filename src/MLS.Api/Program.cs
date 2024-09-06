using Microsoft.OpenApi.Models;
using MLS.Api.Middleware;
using MLS.Application;
using MLS.Infrastructure;
using MLS.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

// Add services to the container
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
ConfigurePipeline(app);

await app.RunAsync();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddApplicationServices();
    services.AddInfrastructureServices(configuration);
    services.AddPersistenceServices(configuration);
    services.AddIdentityServices(configuration);

    services.AddControllers();

    // Configure Swagger/OpenAPI
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MatLidStore ASP.NET Core 6 API", Version = "v1" });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Hãy nhập token người dùng sử dụng lược đồ Bearer. Ví dụ: \"Authorization: Bearer {token}\""
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });
}

void ConfigurePipeline(WebApplication matlidstoreapp)
{
    // Use custom middleware for exception handling
    matlidstoreapp.UseMiddleware<ExceptionMiddleware>();

    // Configure CORS policy
    matlidstoreapp.UseCors("MatLidStoreUI");

    // Configure the HTTP request pipeline
    if (matlidstoreapp.Environment.IsDevelopment())
    {
        matlidstoreapp.UseSwagger();
        matlidstoreapp.UseSwaggerUI();
    }

    matlidstoreapp.UseSerilogRequestLogging();
    matlidstoreapp.UseHttpsRedirection();
    matlidstoreapp.UseAuthentication();
    matlidstoreapp.UseAuthorization();

    matlidstoreapp.MapControllers();
}