using System;
using System.Collections.Generic;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;

namespace PolyclinicApp.WPF.Services.ViewModels
{
    internal class ViewModelsService : IViewModelsService
    {
        public List<ViewModel> OpenedViewModels { get; set; }

        private ViewModel _newOpenedViewModel;
        public ViewModel NewOpenedViewModel
        {
            get => _newOpenedViewModel;
            set
            {
                _newOpenedViewModel = value;
                OnViewModelOpened();
            }
        }

        public event Action? NewViewModelOpened;

        protected virtual void OnViewModelOpened()
        {
            if (OpenedViewModels.Contains(_newOpenedViewModel)) return;
            NewViewModelOpened?.Invoke();
            OpenedViewModels.Add(_newOpenedViewModel);
        }

        public bool HasViewModel(ViewModel viewModel) => OpenedViewModels.Contains(viewModel);

        public ViewModelsService()
        {
            OpenedViewModels = new List<ViewModel>();
        }
    }
}