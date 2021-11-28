using PolyclinicApp.WPF.ViewModels.Base;
using System;

namespace PolyclinicApp.WPF.Stores.Navigation
{
    public enum ViewType
    {
        Login,
        Information,
        NewPatient,
        NewAppointment,
        Schedule
    }

    internal interface INavigationStore
    {
        ViewModel? CurrentViewModel { get; set; }

        event Action CurrentViewModelChanged;
    }
}