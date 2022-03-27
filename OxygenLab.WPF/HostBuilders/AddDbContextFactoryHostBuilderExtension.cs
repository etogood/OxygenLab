using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.DataAccess;

namespace OxygenLab.WPF.HostBuilders;

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