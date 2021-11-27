using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using System.Windows.Input;

namespace PolyclinicApp.WPF.ViewModels;

internal class MainViewModel : ViewModel
{
    private readonly INavigationStore _navigationStore;

    #region Commands

    public ICommand? CloseCommand { get; }

    #endregion Commands

    public ViewModel? CurrentViewModel => _navigationStore.CurrentViewModel;

    public MainViewModel(INavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        CloseCommand = new CloseCommand();
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}