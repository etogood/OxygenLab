using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;
using System;
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
            ViewType.Login => new LoginViewModel(_errorViewModel, _messageViewModel, _authorizationService, _navigationStore, this, _loginStore),
            ViewType.Information => new InformationViewModel(_appDbContextFactory),
            ViewType.NewPatient => new NewPatientViewModel(_navigationStore, this, _errorViewModel, _host),
            ViewType.NewAppointment => new NewAppointmentViewModel(),
            ViewType.Schedule => new DoctorsScheduleViewModel(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null)
        };
    }
}