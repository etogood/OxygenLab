using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyclinicApp.WPF.Commands
{
    internal class CreateNewAppointmentCommand : BaseCommand
    {

        public CreateNewAppointmentCommand(IHost host)
        {
        }
        public override bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
