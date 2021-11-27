using PolyclinicApp.WPF.ViewModels.Base;
using System;

namespace PolyclinicApp.WPF.Stores.Navigation
{
    public enum ViewType
    {
        Login,
        Information
    }

    internal interface INavigationStore
    {
        ViewModel? CurrentViewModel { get; set; }

        event Action CurrentViewModelChanged;
    }
}