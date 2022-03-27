using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.DataAccess;
using OxygenLab.Data.Models;
using OxygenLab.WPF.Commands.Base;
using OxygenLab.WPF.Factories.ViewModel;
using OxygenLab.WPF.Stores.Navigation;
using OxygenLab.WPF.ViewModels;
using OxygenLab.WPF.ViewModels.Base;

namespace OxygenLab.WPF.Commands
{
    internal class AddNewExperimentCommand : BaseCommand
    {
        private readonly IHost _host;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly INavigationStore _navigationStore;

        public AddNewExperimentCommand(IHost host)
        {
            _host = host;
            _viewModelFactory = host.Services.GetRequiredService<IViewModelFactory>();
            _navigationStore = host.Services.GetRequiredService<INavigationStore>();
        }

        public override bool CanExecute(object? parameter) => ((NewExperimentViewModel)_viewModelFactory.CreateViewModel(ViewType.NewExperiment)!).IsReadyToAdd();

        public override void Execute(object? parameter)
        {
            try
            {
                var viewModel = (NewExperimentViewModel)_viewModelFactory.CreateViewModel(ViewType.NewExperiment)!;
                using (var context = _host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new []{"Default"}))
                {
                    context.Experiments.Add(new Experiment
                    {
                        DateOfExperiment = viewModel.DateOfExperiment.ToShortDateString(),
                        ExperimentName = viewModel.Name,
                        Description = viewModel.Description,
                        ExecutivePersonId = viewModel.User!.UserId
                    });
                    context.SaveChanges();
                }

                _navigationStore.CurrentViewModel = _host.Services.GetRequiredService<ExperimentsViewModel>();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}