using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.HostBuilders
{
    internal static class AddStoresHostBuilderExtension
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            return host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigationStore, NavigationStore>();
            });
        }
    }
}