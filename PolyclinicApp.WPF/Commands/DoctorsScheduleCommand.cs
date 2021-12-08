using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Stores.Login;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;

namespace PolyclinicApp.WPF.Commands
{
    internal class DoctorsScheduleCommand : BaseCommand
    {
        private readonly ILoginStore _loginStore;
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IHost _host;

        public DoctorsScheduleCommand(ILoginStore loginStore, INavigationStore navigationStore, IViewModelFactory viewModelFactory, IHost host)
        {
            _loginStore = loginStore;
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
            _host = host;
        }

        public override bool CanExecute(object? parameter) => _loginStore.IsLoggedIn;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _host.Services.GetRequiredService<DoctorsScheduleViewModel>();
            // _navigationStore.CurrentViewModel = _viewModelsService.HasViewModel(ViewType.Schedule)
            //     ? _viewModelsService.GetViewModel(ViewType.Schedule)
            //     : _viewModelFactory.CreateViewModel(ViewType.Schedule);
        }
    }
}