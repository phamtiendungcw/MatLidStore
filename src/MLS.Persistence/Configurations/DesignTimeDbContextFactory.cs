using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MLS.Persistence.DatabaseContext;

namespace MLS.Persistence.Configurations
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MatLidStoreDatabaseContext>
    {
        public MatLidStoreDatabaseContext CreateDbContext(string[] args)
        {
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                   .SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.Development.json")
                                                   .Build();

                var builder = new DbContextOptionsBuilder<MatLidStoreDatabaseContext>();
                var connectionString = configuration.GetConnectionString("MatLidConnectionString");

                builder.UseOracle(connectionString);

                return new MatLidStoreDatabaseContext(builder.Options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating DbContext: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                throw;
            }
        }
    }
}