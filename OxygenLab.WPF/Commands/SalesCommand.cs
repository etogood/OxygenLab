using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Commands.Base;
using OxygenLab.WPF.Factories.ViewModel;
using OxygenLab.WPF.Stores.Login;
using OxygenLab.WPF.Stores.Navigation;

namespace OxygenLab.WPF.Commands
{
    internal class SalesCommand : BaseCommand
    {
        private readonly ILoginStore _loginStore;
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;

        public SalesCommand(IHost host)
        {
            _loginStore = host.Services.GetRequiredService<ILoginStore>();
            _navigationStore = host.Services.GetRequiredService<INavigationStore>();
            _viewModelFactory = host.Services.GetRequiredService<IViewModelFactory>();
        }

        public override bool CanExecute(object? parameter) => _loginStore.IsLoggedIn;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.Sales);
        }
    }
}