using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Commands.Base;
using OxygenLab.WPF.Factories.ViewModel;
using OxygenLab.WPF.Stores.Navigation;

namespace OxygenLab.WPF.Commands
{
    internal class NewSaleCommand : BaseCommand
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly INavigationStore _navigationStore;

        public NewSaleCommand(IHost host)
        {
            _viewModelFactory = host.Services.GetRequiredService<IViewModelFactory>();
            _navigationStore = host.Services.GetRequiredService<INavigationStore>();
        }
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.NewSale);
        }
    }
}