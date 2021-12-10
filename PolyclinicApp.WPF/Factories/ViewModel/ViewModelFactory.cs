using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels;
using System;

namespace PolyclinicApp.WPF.Factories.ViewModel;

internal class ViewModelFactory : IViewModelFactory
{
    private readonly IHost _host;

    public ViewModelFactory(IHost host)
    {
        _host = host;
    }

    public ViewModels.Base.ViewModel? CreateViewModel(ViewType viewType)
    {
        return viewType switch
        {
            ViewType.Login => _host.Services.GetRequiredService<LoginViewModel>(),
            ViewType.Information => _host.Services.GetRequiredService<InformationViewModel>(),
            ViewType.NewPatient => _host.Services.GetRequiredService<NewPatientViewModel>(),
            ViewType.NewAppointment => _host.Services.GetRequiredService<NewAppointmentViewModel>(),
            ViewType.Schedule => _host.Services.GetRequiredService<DoctorsScheduleViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, "Unknown ViewType")
        };
    }
}