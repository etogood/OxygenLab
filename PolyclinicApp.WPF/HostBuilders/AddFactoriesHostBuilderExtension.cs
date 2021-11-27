using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Factories.ViewModel;

namespace PolyclinicApp.WPF.HostBuilders;

internal static class AddFactoriesHostBuilderExtension
{
    public static IHostBuilder AddFactories(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
        });
    }
}