using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Commands.Base;
using OxygenLab.WPF.Factories.ViewModel;
using OxygenLab.WPF.Stores.Navigation;

namespace OxygenLab.WPF.Commands
{
    internal class NewExperimentCommand : BaseCommand
    {
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;

        public NewExperimentCommand(IHost host)
        {
            _navigationStore = host.Services.GetRequiredService<INavigationStore>();
            _viewModelFactory = host.Services.GetRequiredService<IViewModelFactory>();
        }

        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.NewExperiment);
        }
    }
}