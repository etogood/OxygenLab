using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.Views.Windows;

namespace PolyclinicApp.WPF.HostBuilders;

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