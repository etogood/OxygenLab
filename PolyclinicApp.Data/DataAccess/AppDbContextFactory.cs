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
            .SetBasePath(@"C:\Users\etogood\source\repos\WPFandCONSOLEapps\.NET 6.0\PolyclinicApp\PolyclinicApp.WPF\bin\Debug\net6.0-windows")
            .AddJsonFile("appdbsettings.json").Build();


            return args[0] switch
            {
                "Default" => new AppDbContext(optionsBuilder
                    .UseSqlServer(config.GetConnectionString("DefaultConnection")).Options),
                _ => new AppDbContext(optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                    .Options)
            };

    }
}