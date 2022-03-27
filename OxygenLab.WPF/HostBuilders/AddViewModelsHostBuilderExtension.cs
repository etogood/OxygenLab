using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.ViewModels;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.HostBuilders;

internal static class AddViewModelsHostBuilderExtension
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddSingleton<MainViewModel>();
            services.AddScoped<LoginViewModel>();
            services.AddSingleton<ErrorViewModel>();
            services.AddSingleton<MessageViewModel>();
            services.AddSingleton<InformationViewModel>();
            services.AddSingleton<PersonalAccountViewModel>();
            services.AddSingleton<ExperimentsViewModel>();
            services.AddSingleton<NewSaleViewModel>();
            services.AddSingleton<SalesViewModel>();
            services.AddSingleton<NewExperimentViewModel>();
        });
    }
}