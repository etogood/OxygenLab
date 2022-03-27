using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Commands;

namespace OxygenLab.WPF.HostBuilders;

internal static class AddCommandsHostBuilderExtension
{
    public static IHostBuilder AddCommands(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddSingleton<LogInCommand>();
            services.AddSingleton<CloseCommand>();
            services.AddSingleton<PersonalAccountCommand>();
            services.AddSingleton<SalesCommand>();
            services.AddSingleton<ExperimentsCommand>();
            services.AddSingleton<InformationViewCommand>();
            services.AddSingleton<NewExperimentCommand>();
            services.AddSingleton<AddNewExperimentCommand>();
            services.AddSingleton<NewSaleCommand>();
            services.AddSingleton<AddNewSaleCommand>();
        });
    }
}