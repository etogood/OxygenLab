using System.Windows.Input;
using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Factories.Commands;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.ViewModels;

internal class MainViewModel : ViewModel
{
    private readonly INavigationStore _navigationStore;

    #region Commands

    public ICommand? CloseCommand { get; }

    #endregion

    public ViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(INavigationStore navigationStore, ICommandFactory commandFactory)
    {
        _navigationStore = navigationStore;
        CloseCommand = commandFactory.CreateNewCommand(CommandType.Close);
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}