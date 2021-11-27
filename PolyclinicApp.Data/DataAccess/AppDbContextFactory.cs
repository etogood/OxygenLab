using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PolyclinicApp.Data.DataAccess;
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[]? args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>();
        options.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PolyclinicAppDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        return new AppDbContext(options.Options);
    }
}