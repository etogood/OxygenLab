using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Factories.Command;
using OxygenLab.WPF.Factories.ViewModel;

namespace OxygenLab.WPF.HostBuilders;

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