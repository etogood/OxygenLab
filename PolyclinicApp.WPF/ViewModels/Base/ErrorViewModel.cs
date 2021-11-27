using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyclinicApp.WPF.ViewModels.Base
{
    internal class ErrorViewModel : INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors;
        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _errors!.GetValueOrDefault(propertyName, null)!;
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if(!_errors.ContainsKey(propertyName))
                _errors.Add(propertyName, new List<string>());
            _errors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        public void ClearErrors(string propertyName)
        {
            if(_errors.Remove(propertyName))
                OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
