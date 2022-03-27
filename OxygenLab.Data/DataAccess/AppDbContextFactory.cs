using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OxygenLab.Data.DataAccess;
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[]? args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../OxygenLab.Data/DataAccess"))
            .AddJsonFile("appdbsettings.json", false, true)
            .AddEnvironmentVariables()
            .Build();
        var connectionString = config.GetConnectionString("DefaultConnection");

        return new AppDbContext(optionsBuilder.UseSqlServer(connectionString).Options);
    }
}