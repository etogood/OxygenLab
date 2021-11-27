using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.Data.DataAccess;

namespace PolyclinicApp.WPF.HostBuilders;

internal static class AddDbContextFactoryHostBuilderExtension
{
    public static IHostBuilder AddDbContext(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddDbContext<AppDbContext>();
            services.AddSingleton<AppDbContextFactory>();
        });
    }
}