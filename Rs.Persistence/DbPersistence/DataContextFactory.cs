using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Rs.Persistence.DbPersistence;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();
        var configurationBuilder = new ConfigurationBuilder();

        if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
        {
            var apiPath = Path.Combine(basePath, "..", "Rs.Api");
            configurationBuilder.SetBasePath(apiPath);
        }
        else
        {
            configurationBuilder.SetBasePath(basePath);
        }

        configurationBuilder
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables();

        var configuration = configurationBuilder.Build();
        var connectionString = configuration.GetConnectionString("Default")
            ?? "Server=(localdb)\\mssqllocaldb;Database=RsDb;Trusted_Connection=True;TrustServerCertificate=True";

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new DataContext(optionsBuilder.Options);
    }
}
