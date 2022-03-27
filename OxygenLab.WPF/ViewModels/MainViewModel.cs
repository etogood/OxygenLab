using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Commands;
using OxygenLab.WPF.Factories.ViewModel;
using System.Windows.Input;
using OxygenLab.WPF.Factories.Command;
using OxygenLab.WPF.Stores.Login;
using OxygenLab.WPF.Stores.Navigation;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.ViewModels;

internal class MainViewModel : ViewModel
{
    private readonly INavigationStore _navigationStore;
    private readonly ICommandFactory _commandFactory;
    private readonly ILoginStore _loginStore;

    #region Commands

    public ICommand? CloseCommand { get; }
    public ICommand? ExperimentsCommand { get; }
    public ICommand? SalesCommand { get; }
    public ICommand? PersonalAccountCommand { get; }

    #endregion Commands

    public ViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(IHost host)
    {
        _navigationStore = host.Services.GetRequiredService<INavigationStore>();
        _commandFactory = host.Services.GetRequiredService<ICommandFactory>();
        _loginStore = host.Services.GetRequiredService<ILoginStore>();

        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        _loginStore.IsLoggedIn = false;

        ExperimentsCommand = _commandFactory.CreateCommand(CommandType.OpenExperiments);
        SalesCommand = _commandFactory.CreateCommand(CommandType.OpenSales);
        PersonalAccountCommand = _commandFactory.CreateCommand(CommandType.OpenPersonalAccount);
        CloseCommand = _commandFactory.CreateCommand(CommandType.Close);
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}