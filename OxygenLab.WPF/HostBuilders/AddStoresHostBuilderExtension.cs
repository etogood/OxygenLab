using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Stores.Login;
using OxygenLab.WPF.Stores.Navigation;

namespace OxygenLab.WPF.HostBuilders
{
    internal static class AddStoresHostBuilderExtension
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            return host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigationStore, NavigationStore>();
                services.AddSingleton<ILoginStore, LoginStore>();
            });
        }
    }
}