using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.HostBuilders;

internal static class AddViewModelsHostBuilderExtension
{
    public static IHostBuilder AddViewModels(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<ErrorViewModel>();
            services.AddSingleton<MessageViewModel>();
            services.AddSingleton<InformationViewModel>();
            services.AddSingleton<NewAppointmentViewModel>();
            services.AddSingleton<NewPatientViewModel>();
            services.AddSingleton<DoctorsScheduleViewModel>();
        });
    }
}