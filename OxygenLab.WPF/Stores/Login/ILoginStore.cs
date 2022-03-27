using System;
using OxygenLab.Data.Models;

namespace OxygenLab.WPF.Stores.Login;

internal interface ILoginStore
{
    public User CurrentUser { get; set; }
    bool IsLoggedIn { get; set; }
    event Action IsLoggedInChanged;
}