using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.DataAccess;
using OxygenLab.Data.Models;
using OxygenLab.WPF.Commands;
using OxygenLab.WPF.Factories.Command;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.ViewModels
{
    internal class NewExperimentViewModel : ViewModel
    {
        public ICommand AddNewExperimentCommand { get; set; }

        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private DateTime _dateOfExperiment;

        public DateTime DateOfExperiment
        {
            get => _dateOfExperiment;
            set => Set(ref _dateOfExperiment, value);
        }

        private User? _user;

        public User? User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        private List<User> _usersList;

        public List<User> UsersList
        {
            get => _usersList;
            set => Set(ref _usersList, value);
        }


        private string _description;

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        public NewExperimentViewModel(IHost host)
        {
            AddNewExperimentCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.CreateNewExperiment)!;
            _user = null;
            using var appDbContext = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new []{"Default"});
            _usersList = new List<User>(appDbContext.Users);
        }

        public bool IsReadyToAdd()
        {
            return _name != string.Empty 
                   && _description != string.Empty 
                   && _dateOfExperiment != DateTime.MinValue 
                   && _user != null;
        }
    }
}