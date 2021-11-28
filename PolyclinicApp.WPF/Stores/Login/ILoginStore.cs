using System;

namespace PolyclinicApp.WPF.Stores.Login;

internal interface ILoginStore
{
    bool IsLoggedIn { get; set; }
    event Action IsLoggedInChanged;
}