using System;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.Stores.Navigation
{
    

    internal interface INavigationStore
    {
        ViewModel? CurrentViewModel { get; set; }

        event Action CurrentViewModelChanged;
    }
}