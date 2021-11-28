using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Stores.Login;
using System;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.ViewModels;
using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.Commands
{
    internal class DoctorsScheduleCommand : BaseCommand
    {
        private readonly ILoginStore _loginStore;
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IViewModelsService _viewModelsService;

        public DoctorsScheduleCommand(ILoginStore loginStore, INavigationStore navigationStore, IViewModelFactory viewModelFactory, IViewModelsService viewModelsService)
        {
            _loginStore = loginStore;
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
            _viewModelsService = viewModelsService;
        }

        public override bool CanExecute(object? parameter) => _loginStore.IsLoggedIn;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelsService.HasViewModel(ViewType.Schedule)
                ? _viewModelsService.GetViewModel(ViewType.Schedule)
                : _viewModelFactory.CreateViewModel(ViewType.Schedule);
        }
    }
}