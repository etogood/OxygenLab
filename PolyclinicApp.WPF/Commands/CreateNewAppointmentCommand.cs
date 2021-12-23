using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.ViewModels;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF.Commands
{
    internal class CreateNewAppointmentCommand : BaseCommand
    {
        private readonly IHost _host;


        public CreateNewAppointmentCommand(IHost host)
        {
            _host = host;
        }

        public override bool CanExecute(object? parameter) =>
            _host.Services.GetRequiredService<NewAppointmentViewModel>().ArePropertiesNull();

        public override void Execute(object? parameter)
        {
            var viewModel = (NewAppointmentViewModel)_host.Services.GetRequiredService<IViewModelFactory>().CreateViewModel(ViewType.NewAppointment)!;
            try
            {
                using (var context = _host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(null))
                {
                    context.MedicineCards!.Add(new MedicineCard
                    {
                        Patient = viewModel.SelectedPatient,
                        Disease = viewModel.Disease,
                        DateOfDiagnosis = viewModel.AppointmentDateTime,
                        Doctor = viewModel.SelectedDoctor
                    });
                    context.SaveChanges();
                }
                _host.Services.GetRequiredService<InformationViewModel>().OnPropertyChanged();
            }
            catch (DbUpdateException)
            {
                viewModel.ErrorMessage = "Ошибка обновления базы данных";
            }
        }
    }
}
