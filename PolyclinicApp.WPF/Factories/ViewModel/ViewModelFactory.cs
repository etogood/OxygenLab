using PolyclinicApp.WPF.Services.Authorization;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;
using System;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.WPF.Services.ViewModels;
using PolyclinicApp.WPF.Stores.Login;

namespace PolyclinicApp.WPF.Factories.ViewModel;

internal class ViewModelFactory : IViewModelFactory
{
    private readonly INavigationStore _navigationStore;
    private readonly IViewModelsService _viewModelsService;
    private readonly ILoginStore _loginStore;
    private readonly ErrorViewModel _errorViewModel;
    private readonly MessageViewModel _messageViewModel;
    private readonly IAuthorizationService _authorizationService;
    private readonly AppDbContextFactory _appDbContextFactory;

    public ViewModelFactory(INavigationStore navigationStore, IViewModelsService viewModelsService, ILoginStore loginStore, ErrorViewModel errorViewModel, MessageViewModel messageViewModel, IAuthorizationService authorizationService, AppDbContextFactory appDbContextFactory)
    {
        _navigationStore = navigationStore;
        _viewModelsService = viewModelsService;
        _loginStore = loginStore;
        _errorViewModel = errorViewModel;
        _messageViewModel = messageViewModel;
        _authorizationService = authorizationService;
        _appDbContextFactory = appDbContextFactory;
    }

    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType)
    {
        switch (viewType)
        {
            case ViewType.Login:
                var login = new LoginViewModel(_viewModelsService, _errorViewModel, _messageViewModel, _authorizationService, _navigationStore, this, _loginStore);
                _viewModelsService.OpenedViewModels.Add(ViewType.Login, login);
                return login;
            case ViewType.Information:
                var information = new InformationViewModel(_appDbContextFactory, _viewModelsService);
                _viewModelsService.OpenedViewModels.Add(ViewType.Information, information);
                return information;
            case ViewType.NewPatient:
                var newPatient = new NewPatientViewModel(_navigationStore, this, _viewModelsService);
                _viewModelsService.OpenedViewModels.Add(ViewType.NewPatient, newPatient);
                return newPatient;
            case ViewType.NewAppointment:
                var newAppointment = new NewAppointmentViewModel(_viewModelsService);
                _viewModelsService.OpenedViewModels.Add(ViewType.NewAppointment, newAppointment);
                return newAppointment;
            case ViewType.Schedule:
                var schedule = new DoctorsScheduleViewModel(_viewModelsService);
                _viewModelsService.OpenedViewModels.Add(ViewType.Schedule, schedule);
                return schedule;
            default:
                throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
        }
    }
}