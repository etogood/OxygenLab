using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.ViewModels;
using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.Commands;

internal class NavigationCommand : BaseCommand
{
    private readonly INavigationStore _navigationStore;
    private readonly IViewModelFactory _viewModelFactory;
    private readonly IViewModelsService _viewModelsService;

    public NavigationCommand(INavigationStore navigationStore, IViewModelFactory viewModelFactory, IViewModelsService viewModelsService)
    {
        _navigationStore = navigationStore;
        _viewModelFactory = viewModelFactory;
        _viewModelsService = viewModelsService;
    }

    public override bool CanExecute(object? parameter) => true;

    public override void Execute(object? parameter)
    {
        var viewType = (ViewType)parameter!;
        _navigationStore.CurrentViewModel 
            = _viewModelsService.HasViewModel(viewType) ? _viewModelsService.GetViewModel(ViewType.Information) : _viewModelFactory.CreateViewModel(viewType);
    }
}