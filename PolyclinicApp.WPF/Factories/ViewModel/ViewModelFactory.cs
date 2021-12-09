using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;
using System;
using System.Windows.Media.Media3D;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.WPF.Stores.Login;

namespace PolyclinicApp.WPF.Factories.ViewModel;

internal class ViewModelFactory : IViewModelFactory
{
    private readonly INavigationStore _navigationStore;
    private readonly ILoginStore _loginStore;
    private readonly ErrorViewModel _errorViewModel;
    private readonly MessageViewModel _messageViewModel;
    private readonly IAuthorizationService _authorizationService;
    private readonly AppDbContextFactory _appDbContextFactory;
    private readonly IHost _host;

    public ViewModelFactory(INavigationStore navigationStore, ILoginStore loginStore, ErrorViewModel errorViewModel, MessageViewModel messageViewModel, IAuthorizationService authorizationService, AppDbContextFactory appDbContextFactory, IHost host)
    {
        _navigationStore = navigationStore;
        _loginStore = loginStore;
        _errorViewModel = errorViewModel;
        _messageViewModel = messageViewModel;
        _authorizationService = authorizationService;
        _appDbContextFactory = appDbContextFactory;
        _host = host;
    }

    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Login => _host.Services.GetRequiredService<LoginViewModel>(),
            ViewType.Information => _host.Services.GetRequiredService<InformationViewModel>(),
            ViewType.NewPatient => _host.Services.GetRequiredService<NewPatientViewModel>(),
            ViewType.NewAppointment => _host.Services.GetRequiredService<NewAppointmentViewModel>(),
            ViewType.Schedule => _host.Services.GetRequiredService<DoctorsScheduleViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null)
        };
    }
}