using System.Collections.Generic;
using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using System.Windows.Input;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Login;

namespace PolyclinicApp.WPF.ViewModels;

internal class MainViewModel : ViewModel
{
    private readonly INavigationStore _navigationStore;
    private readonly IHost _host;

    #region Commands

    public ICommand? CloseCommand { get; }
    public ICommand? NewPatientCommand { get; }
    public ICommand? NewAppointmentCommand { get; }
    public ICommand? DoctorsScheduleCommand { get; }

    #endregion Commands

    public ViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(INavigationStore navigationStore, ILoginStore loginStore, IViewModelFactory viewModelFactory, IHost host)
    {
        _navigationStore = navigationStore;
        _host = host;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        loginStore.IsLoggedIn = false;
        NewPatientCommand = new NewPatientCommand(loginStore, navigationStore,  viewModelFactory, host);
        NewAppointmentCommand = new NewAppointmentCommand(loginStore, navigationStore, viewModelFactory, host );
        DoctorsScheduleCommand = new DoctorsScheduleCommand(loginStore, navigationStore, viewModelFactory, host);
        CloseCommand = new CloseCommand();
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}