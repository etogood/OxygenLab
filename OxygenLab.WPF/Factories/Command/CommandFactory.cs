using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Input;
using OxygenLab.WPF.Commands;

namespace OxygenLab.WPF.Factories.Command
{
    internal class CommandFactory : ICommandFactory
    {
        private readonly IHost _host;

        public CommandFactory(IHost host)
        {
            _host = host;
        }

        public ICommand? CreateCommand(CommandType commandType)
        {
            return commandType switch
            {
                CommandType.Close => _host.Services.GetRequiredService<CloseCommand>(),
                CommandType.Login => _host.Services.GetRequiredService<LogInCommand>(),
                CommandType.OpenPersonalAccount => _host.Services.GetRequiredService<PersonalAccountCommand>(),
                CommandType.OpenExperiments => _host.Services.GetRequiredService<ExperimentsCommand>(),
                CommandType.OpenSales => _host.Services.GetRequiredService<SalesCommand>(),
                CommandType.OpenInfo => _host.Services.GetRequiredService<InformationViewCommand>(),
                CommandType.OpenNewExperiment => _host.Services.GetRequiredService<NewExperimentCommand>(),
                CommandType.CreateNewExperiment =>  _host.Services.GetRequiredService<AddNewExperimentCommand>(),
                CommandType.OpenNewSale => _host.Services.GetRequiredService<NewSaleCommand>(),
                CommandType.CreateNewSale => _host.Services.GetRequiredService<AddNewSaleCommand>(),
                _ => throw new ArgumentOutOfRangeException(nameof(commandType), commandType, "Unknown CommandType")
            };
        }
    }
}
