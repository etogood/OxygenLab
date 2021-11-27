using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF.ViewModels;

internal class InformationViewModel : ViewModel
{
    #region Fields

    private readonly AppDbContextFactory _appDbContextFactory;
    private readonly AppDbContext _appDbContext;
    private readonly INavigationStore _navigationStore;
    private readonly IViewModelFactory _viewModelFactory;

    #endregion Fields

    #region Properties

    private ObservableCollection<MedicineCard> _ordersTable;

    public ObservableCollection<MedicineCard> OrdersTable
    {
        get => _ordersTable;
        set => Set(ref _ordersTable, value);
    }


    #endregion

    #region Ctor

    public InformationViewModel(INavigationStore navigationStore, IViewModelFactory viewModelFactory, AppDbContextFactory appDbContextFactory)
    {
        _navigationStore = navigationStore;
        _viewModelFactory = viewModelFactory;
        _appDbContextFactory = appDbContextFactory;
        using (_appDbContext = _appDbContextFactory.CreateDbContext(null))
        {
            _ordersTable = new ObservableCollection<MedicineCard>(_appDbContext.MedicineCards
                .Include(x => x.Patient)
                .Include(x => x.Doctor)
            );
        }
    }

    #endregion Ctor
}