using System.Windows;
using OxygenLab.WPF.Commands.Base;

namespace OxygenLab.WPF.Commands
{
    internal class CloseCommand : BaseCommand
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            var result = MessageBox.Show("Вы действительно хойтите выйти?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}