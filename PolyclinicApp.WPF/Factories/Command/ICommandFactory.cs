﻿
using System.Windows.Input;

namespace PolyclinicApp.WPF.Factories.Command
{
    public enum CommandType
    {
        Close,
        OpenSchedule,
        OpenNewPatient,
        OpenNewAppointment,
        OpenInfo,
        CreateNewPatient,
        CreateNewAppointment
    }

    internal interface ICommandFactory
    {
        public ICommand? CreateCommand(CommandType commandType);
    }
}