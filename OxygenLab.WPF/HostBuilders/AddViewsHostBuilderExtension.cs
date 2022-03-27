using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Views.Windows;

namespace OxygenLab.WPF.HostBuilders;

internal static class AddViewsHostBuilderExtension
{
    public static IHostBuilder AddViews(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddSingleton<MainWindow>();
        });
    }
}