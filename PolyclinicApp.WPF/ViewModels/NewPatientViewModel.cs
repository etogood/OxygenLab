using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyclinicApp.WPF.Services.ViewModels;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.ViewModels
{
    internal class NewPatientViewModel : ViewModel
    {
        public NewPatientViewModel(IViewModelsService viewModelsService)
        {
            viewModelsService.NewOpenedViewModel = this;
        }
    }
}
