using System.Collections.Generic;
using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using System.Windows.Input;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.ViewModels;
using PolyclinicApp.WPF.Stores.Login;

namespace PolyclinicApp.WPF.ViewModels;

internal class MainViewModel : ViewModel
{
    private readonly INavigationStore _navigationStore;

    #region Commands

    public ICommand? CloseCommand { get; }
    public ICommand? NewPatientCommand { get; }
    public ICommand? NewAppointmentCommand { get; }
    public ICommand? DoctorsScheduleCommand { get; }

    #endregion Commands

    public ViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(INavigationStore navigationStore, ILoginStore loginStore, IViewModelFactory viewModelFactory, IViewModelsService viewModelsService)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        loginStore.IsLoggedIn = false;
        NewPatientCommand = new NewPatientCommand(loginStore, navigationStore,  viewModelFactory, viewModelsService);
        NewAppointmentCommand = new NewAppointmentCommand(loginStore, navigationStore, viewModelFactory, viewModelsService);
        DoctorsScheduleCommand = new DoctorsScheduleCommand(loginStore, navigationStore, viewModelFactory, viewModelsService);
        CloseCommand = new CloseCommand();
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}