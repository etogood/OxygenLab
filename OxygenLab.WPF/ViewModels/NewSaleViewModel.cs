using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.DataAccess;
using OxygenLab.Data.Models;
using OxygenLab.WPF.Factories.Command;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.ViewModels
{
    internal class NewSaleViewModel : ViewModel
    {
        public ICommand AddNewSaleCommand { get; set; }

        private Reagent? _reagent;

        public Reagent? Reagent
        {
            get => _reagent;
            set => Set(ref _reagent, value);
        }

        private List<Reagent> _reagentsList;

        public List<Reagent> ReagentsList
        {
            get => _reagentsList;
            set => Set(ref _reagentsList, value);
        }

        private DateTime _dateOfSale;

        public DateTime DateOfSale
        {
            get => _dateOfSale;
            set => Set(ref _dateOfSale, value);
        }

        private Client? _client;

        public Client? Client
        {
            get => _client;
            set => Set(ref _client, value);
        }

        private List<Client> _clientsList;

        public List<Client> ClientsList
        {
            get => _clientsList;
            set => Set(ref _clientsList, value);
        }


        private int _amount;

        public int Amount
        {
            get => _amount;
            set => Set(ref _amount, value);
        }
        public NewSaleViewModel(IHost host)
        {
            Reagent = null;
            Client = null;
            AddNewSaleCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.CreateNewSale)!;
            using (var context = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new []{"Default"}))
            {
                _reagentsList = new List<Reagent>(context.Reagents);
                _clientsList = new List<Client>(context.Clients);
            }
        }

        public bool IsReadyToAdd()
        {
            return _amount > 0
                   && _client != null
                   && _dateOfSale != DateTime.MinValue
                   && _reagent != null;
        }
    }
}