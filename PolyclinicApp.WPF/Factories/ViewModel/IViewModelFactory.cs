using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.Factories.ViewModel;

internal interface IViewModelFactory
{
    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType);
}

