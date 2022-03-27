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
        private ObservableCollection<Sale> _salesTable;
        
        public ObservableCollection<Sale> SalesTable
        {
            get => _salesTable;
            set => Set(ref _salesTable, value);
        }

        public ICommand NewSaleCommand { get; set; }

        public SalesViewModel(IHost host)
        {
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