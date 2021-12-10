using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Commands;
using System;
using System.Windows.Input;

namespace PolyclinicApp.WPF.Factories.Command
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
                CommandType.OpenSchedule => _host.Services.GetRequiredService<DoctorsScheduleCommand>(),
                CommandType.OpenNewPatient => _host.Services.GetRequiredService<NewPatientCommand>(),
                CommandType.OpenNewAppointment => _host.Services.GetRequiredService<NewAppointmentCommand>(),
                CommandType.OpenInfo => _host.Services.GetRequiredService<InformationViewCommand>(),
                CommandType.CreateNewPatient => _host.Services.GetRequiredService<CreateNewPatientCommand>(),
                CommandType.CreateNewAppointment => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(commandType), commandType, "Unknown CommandType")
            };
        }
    }
}
