using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PolyclinicApp.WPF.ViewModels.Base;

internal class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool Set<T>(ref T field, T value, [CallerMemberName] string? proppertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(proppertyName);
        return true;
    }
}