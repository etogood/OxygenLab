namespace PolyclinicApp.WPF.ViewModels.Base
{
    internal class MessageViewModel : ViewModel
    {
        public bool HasMessage => !string.IsNullOrEmpty(_message);

        private string? _message;

        public string? Message
        {
            get => _message;
            set
            {
                Set(ref _message, value);
                OnPropertyChanged(nameof(HasMessage));
            }
        }
    }
}