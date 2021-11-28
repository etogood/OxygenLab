using System;
using System.Collections.Generic;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.Services.ViewModels
{
    internal sealed class ViewModelsService : IViewModelsService
    {
        public Dictionary<ViewType, ViewModel?> OpenedViewModels { get; set; }

        public bool HasViewModel(ViewType viewType) => OpenedViewModels.ContainsKey(viewType);

        public ViewModel? GetViewModel(ViewType viewType)
        {
            OpenedViewModels.TryGetValue(viewType, out var viewModel);
            return viewModel;
        }

        public Dictionary<ViewType, ViewModel?>.ValueCollection GetAllViewModels() => OpenedViewModels.Values;

        public ViewModelsService()
        {

            OpenedViewModels = new Dictionary<ViewType, ViewModel?>();
        }
    }
}