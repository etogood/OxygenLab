using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.Commands
{
    internal class CreateNewPatientCommand : BaseCommand
    {
        private readonly NewPatientViewModel _viewModel;

        public CreateNewPatientCommand(NewPatientViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            bool v = !_viewModel.ArePropertiesNull();
            return !_viewModel.ArePropertiesNull();
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
