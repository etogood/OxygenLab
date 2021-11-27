using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.Commands;

internal class NavigationCommand : BaseCommand
{
    private readonly INavigationStore _navigationStore;
    private readonly IViewModelFactory _viewModelFactory;

    public NavigationCommand(INavigationStore navigationStore, IViewModelFactory viewModelFactory)
    {
        _navigationStore = navigationStore;
        _viewModelFactory = viewModelFactory;
    }

    public override bool CanExecute(object? parameter) => true;

    public override void Execute(object? parameter)
    {
        var viewType = (ViewType)parameter!;
        _navigationStore.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
    }
}