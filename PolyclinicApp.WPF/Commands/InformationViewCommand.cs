using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;

namespace PolyclinicApp.WPF.Commands
{
    internal class InformationViewCommand : BaseCommand
    {
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IHost _host;

        public InformationViewCommand(INavigationStore navigationStore, IViewModelFactory viewModelFactory, IHost host)
        {
            _navigationStore = navigationStore;
            _viewModelFactory = viewModelFactory;
            _host = host;
        }
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _host.Services.GetRequiredService<InformationViewModel>();
        }
    }
}
