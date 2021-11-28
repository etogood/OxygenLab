using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Commands;

namespace PolyclinicApp.WPF.HostBuilders;

internal static class AddCommandsHostBuilderExtension
{
    public static IHostBuilder AddCommands(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddSingleton<NavigationCommand>();
            services.AddSingleton<LogInCommand>();
            services.AddSingleton<CloseCommand>();
            services.AddSingleton<DoctorsScheduleCommand>();
            services.AddSingleton<NewAppointmentCommand>();
            services.AddSingleton<NewPatientCommand>();
            services.AddSingleton<InformationViewCommand>();
        });
    }
}