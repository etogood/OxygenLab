using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Services.Users;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF.HostBuilders;

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