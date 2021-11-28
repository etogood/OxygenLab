using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Stores.Login;
using System;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.ViewModels;
using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.Commands
{
    internal class NewAppointmentCommand : BaseCommand
    {
        private readonly ILoginStore _loginStore;
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IViewModelsService _viewModelsService;

        public NewAppointmentCommand(ILoginStore loginStore, INavigationStore navigationStore, IViewModelFactory viewModelFactory, IViewModelsService viewModelsService)
        {
            _loginStore = loginStore;
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
            _viewModelsService = viewModelsService;
        }

        public override bool CanExecute(object? parameter) => _loginStore.IsLoggedIn;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelsService.HasViewModel(ViewType.NewAppointment)
                ? _viewModelsService.GetViewModel(ViewType.NewAppointment)
                : _viewModelFactory.CreateViewModel(ViewType.NewAppointment);
        }
    }
}