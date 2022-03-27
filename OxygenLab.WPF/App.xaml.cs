using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.HostBuilders;
using System.Windows;
using OxygenLab.Data.DataAccess;
using OxygenLab.WPF.Factories.ViewModel;
using OxygenLab.WPF.Stores.Navigation;
using OxygenLab.WPF.ViewModels;
using OxygenLab.WPF.Views.Windows;

namespace OxygenLab.WPF;

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
        await _host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new []{"Default"}).Database.MigrateAsync();
        _host.Services.GetRequiredService<INavigationStore>().CurrentViewModel =
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