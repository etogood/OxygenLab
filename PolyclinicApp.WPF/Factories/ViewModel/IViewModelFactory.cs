using PolyclinicApp.WPF.Stores.Navigation;

namespace PolyclinicApp.WPF.Factories.ViewModel;

public enum ViewType
{
    Login,
    Information,
    NewPatient,
    NewAppointment,
    Schedule
}
internal interface IViewModelFactory
{
    

    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType);
}