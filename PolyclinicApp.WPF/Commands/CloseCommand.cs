using PolyclinicApp.WPF.Commands.Base;
using System.Windows;

namespace PolyclinicApp.WPF.Commands
{
    internal class CloseCommand : BaseCommand
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            var result = MessageBox.Show("Вы действительно хойтите выйти?", "Подтвердите действие", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}