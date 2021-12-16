using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PolyclinicApp.Data.DataAccess;


public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[]? args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appdbsettings.json").Build();



        return args![0] switch
        {
            "Default" => new AppDbContext(optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection")).Options),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}