using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.DataAccess;
using OxygenLab.Data.Models;
using OxygenLab.WPF.ViewModels.Base;
using System.Collections.ObjectModel;

namespace OxygenLab.WPF.ViewModels;

internal class InformationViewModel : ViewModel
{
    #region Properties

    private ObservableCollection<Reagent> _reagentsTable;

    public ObservableCollection<Reagent> ReagentsTable
    {
        get => _reagentsTable;
        set => Set(ref _reagentsTable, value);
    }

    #endregion Properties

    #region Ctor

    public InformationViewModel(IHost host)
    {
        using (var appDbContext = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new[] { "Default" }))
        {
            _reagentsTable = new ObservableCollection<Reagent>(appDbContext.Reagents);
        }
    }

    #endregion Ctor
}