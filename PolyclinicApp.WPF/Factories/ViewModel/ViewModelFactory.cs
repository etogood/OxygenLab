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
        return viewType switch
        {
            ViewType.Login => new LoginViewModel(_viewModelsService, _errorViewModel, _messageViewModel, _authorizationService, _navigationStore, this, _loginStore),
            ViewType.Information => new InformationViewModel(_appDbContextFactory, _viewModelsService),
            ViewType.NewPatient => new NewPatientViewModel(_viewModelsService),
            ViewType.NewAppointment => new NewAppointmentViewModel(_viewModelsService),
            ViewType.Schedule => new DoctorsScheduleViewModel(_viewModelsService),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null)
        };
    }
}