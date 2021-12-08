using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Stores.Login;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.Commands
{
    internal class NewPatientCommand : BaseCommand
    {
        private readonly ILoginStore _loginStore;
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IHost _host;

        public NewPatientCommand(ILoginStore loginStore, INavigationStore navigationStore, IViewModelFactory viewModelFactory, IHost host)
        {
            _loginStore = loginStore;
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
            _host = host;
        }

        public override bool CanExecute(object? parameter) => _loginStore.IsLoggedIn;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _host.Services.GetRequiredService<NewPatientViewModel>();
        }
    }
}