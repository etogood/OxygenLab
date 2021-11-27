using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.HostBuilders;
using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Services.Users;
using PolyclinicApp.WPF.Stores;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.Views.Windows;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF;
public partial class App : Application
{
    private static IHost _host = null!;

    public App()
    {
        _host = CreateHostBuilder().Build();
    }

    private static IHostBuilder CreateHostBuilder(string[]? args = null) => Host.CreateDefaultBuilder(args)
        .AddStores()
        .AddFactories()
        .AddServices()
        .AddViewModels()
        .AddViews()
        .AddCommands()
        .AddDbContext();

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        var navigationStore = _host.Services.GetRequiredService<INavigationStore>();
        navigationStore.CurrentViewModel =
            _host.Services.GetRequiredService<IViewModelFactory>().CreateViewModel(ViewType.Login);

        MainWindow = _host.Services.GetRequiredService<MainWindow>();
        MainWindow.DataContext = _host.Services.GetRequiredService<MainViewModel>();
        MainWindow.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }
}