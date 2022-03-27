using OxygenLab.WPF.Stores.Navigation;

namespace OxygenLab.WPF.Factories.ViewModel;

public enum ViewType
{
    Login,
    Information,
    NewExperiment,
    Sales,
    PersonalAccount,
    Experiments,
    NewSale
}
internal interface IViewModelFactory
{
    

    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType);
}