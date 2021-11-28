using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Services.ViewModels;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using System.Windows.Input;

namespace PolyclinicApp.WPF.ViewModels
{
    internal class NewPatientViewModel : ViewModel
    {
        public ICommand? InformationViewCommand { get; }

        public NewPatientViewModel(INavigationStore navigationStore, IViewModelFactory viewModelFactory, IViewModelsService viewModelsService)
        {

            InformationViewCommand = new InformationViewCommand(navigationStore, viewModelFactory, viewModelsService);
        }
    }
}