using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Services.Authorization;
using OxygenLab.WPF.Services.Users;
using OxygenLab.Data.Models;

namespace OxygenLab.WPF.HostBuilders;

internal static class AddServicesHostBuilderExtension
{
    public static IHostBuilder AddServices(this IHostBuilder host)
    {
        return host.ConfigureServices(services =>
        {
            services.AddSingleton<IDataService<User>, UsersService>();
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
        });
    }
}