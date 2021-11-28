using System;

namespace PolyclinicApp.WPF.Stores.Login;

internal class LoginStore : ILoginStore
{
    private bool _isLoggedIn;

    public bool IsLoggedIn
    {
        get => _isLoggedIn;
        set
        {
            _isLoggedIn = value;
            IsLoggedInChanged?.Invoke();
        }
    }

    public event Action? IsLoggedInChanged;
}