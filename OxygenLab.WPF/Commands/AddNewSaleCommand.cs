using System;
using System.Linq;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.DataAccess;
using OxygenLab.Data.Models;
using OxygenLab.WPF.Commands.Base;
using OxygenLab.WPF.Factories.ViewModel;
using OxygenLab.WPF.Stores.Navigation;
using OxygenLab.WPF.ViewModels;

namespace OxygenLab.WPF.Commands
{
    internal class AddNewSaleCommand : BaseCommand
    {
        private readonly INavigationStore _navigationStore;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IHost _host;

        public AddNewSaleCommand(IHost host)
        {
            _host = host;
            _viewModelFactory = host.Services.GetRequiredService<IViewModelFactory>();
            _navigationStore = host.Services.GetRequiredService<INavigationStore>();
        }
        public override bool CanExecute(object? parameter) => ((NewSaleViewModel)_viewModelFactory.CreateViewModel(ViewType.NewSale)!).IsReadyToAdd();

        public override void Execute(object? parameter)
        {
            var viewModel = (NewSaleViewModel) _viewModelFactory.CreateViewModel(ViewType.NewSale)!;
            try
            {
                using var context = _host.Services.GetRequiredService<AppDbContextFactory>()
                    .CreateDbContext(new[] {"Default"});

                if (context.Reagents.FirstOrDefault(x => x.ReagentId == viewModel.Reagent!.ReagentId)!.Amount -
                    viewModel.Amount < 0) throw new ArgumentOutOfRangeException();

                context.Sales.Add(new Sale
                {
                    ReagentId = viewModel.Reagent!.ReagentId,
                    Amount = viewModel.Amount,
                    ClientId = viewModel.Client!.ClientId,
                    DateOfSale = viewModel.DateOfSale
                });

                context.Reagents
                    .Update(context.Reagents.FirstOrDefault(x => x.ReagentId == viewModel.Reagent!.ReagentId)!).Entity
                    .Amount -= viewModel.Amount;

                context.SaveChanges();
            }
            catch (ArgumentOutOfRangeException)
            {
                using var context = _host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new[] { "Default" });
                var amount = context.Reagents.FirstOrDefault(x => x.ReagentId == viewModel.Reagent!.ReagentId)!
                    .Amount;
                MessageBox.Show($"На складе осталось только {amount} ед. этого товара");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }

            _navigationStore.CurrentViewModel = _viewModelFactory.CreateViewModel(ViewType.NewSale);
        }
    }
}