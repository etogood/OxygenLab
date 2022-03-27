using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OxygenLab.Data.DataAccess;
using OxygenLab.WPF.Commands;
using OxygenLab.WPF.Factories.Command;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.ViewModels
{
    internal class SalesViewModel : ViewModel
    {
        public ICommand BackCommand { get; }
        private readonly IHost _host;
        private ObservableCollection<Sale> _salesTable;
        
        public ObservableCollection<Sale> SalesTable
        {
            get
            {
                using var appDbContext = _host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new[] { "Default" });
                return new ObservableCollection<Sale>(appDbContext.Sales
                    .Include(x => x.Client)
                    .Include(x => x.Reagent));
            }
            set => Set(ref _salesTable, value);
        }

        public ICommand NewSaleCommand { get; set; }

        public SalesViewModel(IHost host)
        {
            BackCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.OpenInfo)!;

            _host = host;
            NewSaleCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.OpenNewSale)!;
            using (var appDbContext = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new [] { "Default" }))
            {
                _salesTable = new ObservableCollection<Sale>(appDbContext.Sales
                    .Include(x => x.Client)
                    .Include(x => x.Reagent));
            }
        }

    }
}