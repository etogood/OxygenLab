using PolyclinicApp.WPF.Commands.Base;
using System.Windows;

namespace PolyclinicApp.WPF.Commands
{
    internal class CloseCommand : BaseCommand
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter)
        {
            var result = MessageBox.Show("Вы действительно хойтите выйти?", "Подтвердите действие", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
            
            
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("kek");
                    break;
            }
        }
    }
}