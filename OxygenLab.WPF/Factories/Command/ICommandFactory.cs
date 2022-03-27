
using System.Windows.Input;

namespace OxygenLab.WPF.Factories.Command
{
    public enum CommandType
    {
        Close,
        OpenPersonalAccount,
        OpenExperiments,
        OpenSales,
        OpenNewSale,
        OpenInfo,
        OpenNewExperiment,
        CreateNewExperiment,
        CreateNewSale,
        Login
    }

    internal interface ICommandFactory
    {
        public ICommand? CreateCommand(CommandType commandType);
    }
}
