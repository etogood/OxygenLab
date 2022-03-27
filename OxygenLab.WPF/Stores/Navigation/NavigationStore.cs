using System;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.Stores.Navigation;

internal class NavigationStore : INavigationStore
{
    private ViewModel? _currentViewModel;

    public ViewModel? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            CurrentViewModelChanged?.Invoke();
        }
    }

    public event Action? CurrentViewModelChanged;
}