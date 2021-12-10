using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.Commands
{
    internal class CreateNewPatientCommand : BaseCommand
    {
        private readonly IHost _host;

        public CreateNewPatientCommand(IHost host)
        {
            _host = host;
        }

        public override bool CanExecute(object? parameter) => 
            !_host.Services.GetRequiredService<NewPatientViewModel>().ArePropertiesNull();

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
