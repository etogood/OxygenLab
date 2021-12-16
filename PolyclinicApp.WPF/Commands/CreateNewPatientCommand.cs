using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.WPF.Commands.Base;
using PolyclinicApp.WPF.ViewModels;
using System;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF.Commands
{
    internal class CreateNewPatientCommand : BaseCommand
    {
        private readonly IHost _host;

        public CreateNewPatientCommand(IHost host)
        {
            _host = host;
        }

        public override bool CanExecute(object? parameter) => _host.Services.GetRequiredService<NewPatientViewModel>().ArePropertiesNull();

        public override void Execute(object? parameter)
        {
            var viewModel = _host.Services.GetRequiredService<NewPatientViewModel>();
            try
            {
                using (var context = _host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new[] { "Default" }))
                {
                    context.Patients!.Add(new Patient
                    {
                        Surname = viewModel.Surname,
                        FirstName = viewModel.FirstName,
                        Patronymic = viewModel.Patronymic,
                        DateOfBirth = viewModel.DateOfBirth,
                        InsuranceIndividualPersonalAccountNumber = viewModel.Iipan,

                        Address = new Address
                        {
                            City = viewModel.AddressCity,
                            House = viewModel.AddressHouse,
                            Street = viewModel.AddressStreet,
                            Other = viewModel.AddressOther
                        },

                        Passport = new Passport
                        {
                            PassportCode = viewModel.PassportCode,
                            PassportDate = viewModel.PassportDate,
                            PassportExtraditionPlace = viewModel.PassportExtraditionPlace,
                            PassportNumber = viewModel.PassportNumber
                        },

                        MedicalInsurance = new MedicalInsurance
                        {
                            DateOfIssue = viewModel.DateOfIssue,
                            InsuranceCompanyName = viewModel.InsuranceCompanyName,
                            MedicalInsuranceNumber = viewModel.MedicalInsuranceNumber,
                        }
                    });
                    context.SaveChanges();
                }
                viewModel.Clear();
                viewModel.ErrorMessage = "Пациент успешно добавлен";
            }
            catch (Exception)
            {
                viewModel.ErrorMessage = "Что-то пошло не так, обратитесь к администратору";
            }
        }
    }
}