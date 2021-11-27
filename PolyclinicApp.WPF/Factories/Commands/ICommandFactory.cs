using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyclinicApp.WPF.Commands.Base;

namespace PolyclinicApp.WPF.Factories.Commands
{
    internal interface ICommandFactory
    {
        public BaseCommand? CreateNewCommand(CommandType commandType);
    }
}
