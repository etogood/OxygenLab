using PolyclinicApp.WPF.ViewModels.Base;
using System;

namespace PolyclinicApp.WPF.Stores.Navigation;

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