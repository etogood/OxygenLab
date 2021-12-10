using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Factories.Command;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Login;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using System.Windows.Input;

namespace PolyclinicApp.WPF.ViewModels;

internal class MainViewModel : ViewModel
{
    private readonly INavigationStore _navigationStore;
    private readonly ICommandFactory _commandFactory;
    private readonly ILoginStore _loginStore;

    #region Commands

    public ICommand? CloseCommand { get; }
    public ICommand? NewPatientCommand { get; }
    public ICommand? NewAppointmentCommand { get; }
    public ICommand? DoctorsScheduleCommand { get; }

    #endregion Commands

    public ViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(IHost host)
    {
        _navigationStore = host.Services.GetRequiredService<INavigationStore>();
        _commandFactory = host.Services.GetRequiredService<ICommandFactory>();
        _loginStore = host.Services.GetRequiredService<ILoginStore>();

        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _loginStore.IsLoggedIn = false;

        NewPatientCommand = _commandFactory.CreateCommand(CommandType.OpenNewPatient);
        NewAppointmentCommand = _commandFactory.CreateCommand(CommandType.OpenNewAppointment);
        DoctorsScheduleCommand = _commandFactory.CreateCommand(CommandType.OpenSchedule);
        CloseCommand = _commandFactory.CreateCommand(CommandType.Close);
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}