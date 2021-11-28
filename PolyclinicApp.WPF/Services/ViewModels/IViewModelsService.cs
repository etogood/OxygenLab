using System;
using System.Collections.Generic;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.Services.ViewModels;

internal interface IViewModelsService
{
    List<ViewModel> OpenedViewModels { get; set; }
    ViewModel NewOpenedViewModel { get; set; }
    bool HasViewModel(ViewModel viewModel);
    event Action? NewViewModelOpened;


}