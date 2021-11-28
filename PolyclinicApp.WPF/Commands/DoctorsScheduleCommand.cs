using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Stores.Login;
using System;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.Commands
{
    internal class DoctorsScheduleCommand : BaseCommand
    {
        private readonly ILoginStore _loginStore;
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;

        public DoctorsScheduleCommand(ILoginStore loginStore, INavigationStore navigationStore, IViewModelFactory viewModelFactory)
        {
            _loginStore = loginStore;
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
        }

        public override bool CanExecute(object? parameter) => _loginStore.IsLoggedIn;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.Schedule);
        }
    }
}