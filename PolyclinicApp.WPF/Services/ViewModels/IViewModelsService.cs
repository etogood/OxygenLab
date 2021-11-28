using System;
using System.Collections.Generic;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.Services.ViewModels;

internal interface IViewModelsService
{
    Dictionary<ViewType, ViewModel?> OpenedViewModels { get; set; }

    public bool HasViewModel(ViewType viewType);

    public ViewModel? GetViewModel(ViewType viewType);

    public Dictionary<ViewType, ViewModel?>.ValueCollection GetAllViewModels();
}