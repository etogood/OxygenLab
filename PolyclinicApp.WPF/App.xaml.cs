using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.HostBuilders;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.Views.Windows;
using System.Windows;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.Data.AutoMapper;

namespace PolyclinicApp.WPF;

public partial class App : Application
{
    private static IHost _host = null!;
    private static IMapper _mapper;

    public App()
    {
        _host = CreateHostBuilder().Build();
        _mapper = CreateMapperConfiguration().CreateMapper();
    }

    private static IHostBuilder CreateHostBuilder(string[]? args = null) => Host.CreateDefaultBuilder(args)
        .AddStores()
        .AddFactories()
        .AddServices()
        .AddViewModels()
        .AddViews()
        .AddCommands()
        .AddDbContext()
        .AddMappingProfiles();

    private static MapperConfiguration CreateMapperConfiguration() =>
        new MapperConfiguration(cfg => cfg.AddProfile(_host.Services.GetRequiredService<Profile>()));

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();
        await _host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(null).Database.MigrateAsync();
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