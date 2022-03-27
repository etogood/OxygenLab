using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.WPF.Commands;
using OxygenLab.WPF.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using OxygenLab.Data.DataAccess;
using OxygenLab.Data.Models;
using OxygenLab.WPF.Factories.Command;

namespace OxygenLab.WPF.ViewModels
{
    internal class ExperimentsViewModel : ViewModel
    {
        public readonly IHost _host;


        #region Fields

        private readonly ErrorViewModel _errorViewModel;

        #endregion Fields

        #region Commands

        public ICommand? InformationViewCommand { get; }
        public ICommand? CreateNewExperimentCommand { get; }
        public ICommand BackCommand { get; }

        #endregion Commands

        #region Properties

        private ObservableCollection<Experiment> _experimentsTable;

        public ObservableCollection<Experiment> ExperimentsTable
        {
            get
            {
                using var appDbContext = _host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new[] { "Default" });
                return new ObservableCollection<Experiment>(appDbContext.Experiments
                    .Include(x => x.User));
            }
            set => Set(ref _experimentsTable, value);
            
}


        public MessageViewModel MessageViewModel { get; }

        public string? ErrorMessage
        {
            set => MessageViewModel.Message = value;
        }

        public bool HasErrors => _errorViewModel.HasErrors;

        #endregion Properties

        #region Ctor

        public ExperimentsViewModel(IHost host)
        {
            BackCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.OpenInfo)!;
            _host = host;
            _errorViewModel = host.Services.GetRequiredService<ErrorViewModel>();
            InformationViewCommand = host.Services.GetRequiredService<InformationViewCommand>();
            MessageViewModel = host.Services.GetRequiredService<MessageViewModel>();
            CreateNewExperimentCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.OpenNewExperiment);
            using (var appDbContext = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new []{"Default"}))
            {
                _experimentsTable = new ObservableCollection<Experiment>(appDbContext.Experiments
                    .Include(x => x.User));
            }
        }

        #endregion Ctor
    }
}