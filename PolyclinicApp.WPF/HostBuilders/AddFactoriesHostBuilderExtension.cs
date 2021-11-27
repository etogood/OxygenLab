using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Factories.Commands;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores;
using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.HostBuilders;

internal static class AddFactoriesHostBuilderExtension
{
    public static IHostBuilder AddFactories(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddSingleton<ICommandFactory, CommandFactory>();
        });
    }
}

