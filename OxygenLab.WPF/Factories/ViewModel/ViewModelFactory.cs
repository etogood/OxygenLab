using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.ViewModels;
using System;

namespace OxygenLab.WPF.Factories.ViewModel;

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
            ViewType.Experiments => _host.Services.GetRequiredService<ExperimentsViewModel>(),
            ViewType.NewExperiment => _host.Services.GetRequiredService<NewExperimentViewModel>(),
            ViewType.Sales => _host.Services.GetRequiredService<SalesViewModel>(),
            ViewType.PersonalAccount => _host.Services.GetRequiredService<PersonalAccountViewModel>(),
            ViewType.NewSale => _host.Services.GetRequiredService<NewSaleViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(viewType), viewType, "Unknown ViewType")
        };
    }
}