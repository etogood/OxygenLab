using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.ViewModels;
using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.Commands
{
    internal class InformationViewCommand : BaseCommand
    {
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IViewModelsService _viewModelsService;

        public InformationViewCommand(INavigationStore navigationStore, IViewModelFactory viewModelFactory, IViewModelsService viewModelsService)
        {
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
            _viewModelsService = viewModelsService;
        }
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelsService.HasViewModel(ViewType.Information)
                ? _viewModelsService.GetViewModel(ViewType.Information)
                : _viewModelFactory.CreateViewModel(ViewType.Information);
        }
    }
}
