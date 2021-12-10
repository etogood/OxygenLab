using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF.ViewModels;

internal class InformationViewModel : ViewModel
{

    #region Properties

    private ObservableCollection<MedicineCard> _ordersTable;

    public ObservableCollection<MedicineCard> OrdersTable
    {
        get => _ordersTable;
        set => Set(ref _ordersTable, value);
    }


    #endregion

    #region Ctor

    public InformationViewModel(IHost host)
    {
        using (var appDbContext = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(null))
        {
            _ordersTable = new ObservableCollection<MedicineCard>(appDbContext.MedicineCards!
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
            );
        }


    }

    #endregion Ctor
}