using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Commands.Base;
using OxygenLab.WPF.Factories.ViewModel;
using OxygenLab.WPF.Stores.Login;
using OxygenLab.WPF.Stores.Navigation;
using OxygenLab.WPF.ViewModels;

namespace OxygenLab.WPF.Commands
{
    internal class PersonalAccountCommand : BaseCommand
    {
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ILoginStore _loginStore;

        public PersonalAccountCommand(IHost host)
        {
            _navigationStore = host.Services.GetRequiredService<INavigationStore>();
            _viewModelFactory = host.Services.GetRequiredService<IViewModelFactory>();
            _loginStore = host.Services.GetRequiredService<ILoginStore>();
        }

        public override bool CanExecute(object? parameter) => _loginStore.IsLoggedIn;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.PersonalAccount);
        }
    }
}