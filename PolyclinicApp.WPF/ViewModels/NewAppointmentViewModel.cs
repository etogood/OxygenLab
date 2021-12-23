using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyclinicApp.Data.DataAccess;
using PolyclinicApp.Data.Models;
using PolyclinicApp.WPF.Factories.Command;
using PolyclinicApp.WPF.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PolyclinicApp.WPF.ViewModels
{
    internal class NewAppointmentViewModel : ViewModel
    {
        #region Fields

        private readonly ErrorViewModel _errorViewModel;

        #endregion Fields

        #region Propertis

        private ObservableCollection<Patient> _patientsComboBox;

        public ObservableCollection<Patient> PatientsComboBox
        {
            get => _patientsComboBox;
            set
            {
                if (!Set(ref _patientsComboBox, value)) return;
                _errorViewModel.ClearErrors(nameof(PatientsComboBox));
                if (_selectedPatient == null)
                    _errorViewModel.AddError(nameof(PatientsComboBox), "Выберите пациента");
            }
        }

        private ObservableCollection<Doctor> _doctorsComboBox;

        public ObservableCollection<Doctor> DoctorsComboBox
        {
            get => _doctorsComboBox;
            set
            {
                if (!Set(ref _doctorsComboBox, value)) return;
                _errorViewModel.ClearErrors(nameof(DoctorsComboBox));
                if (_selectedDoctor == null)
                    _errorViewModel.AddError(nameof(DoctorsComboBox), "Выберите лечащего врача");
            }
        }

        private Patient? _selectedPatient;

        public Patient? SelectedPatient
        {
            get => _selectedPatient;
            set => Set(ref _selectedPatient, value);
        }

        private Doctor? _selectedDoctor;

        public Doctor? SelectedDoctor
        {
            get => _selectedDoctor;
            set => Set(ref _selectedDoctor, value);
        }

        private string _disease;

        public string Disease
        {
            get => _disease;
            set
            {
                if (!Set(ref _disease, value)) return;
                _errorViewModel.ClearErrors(nameof(Disease));
                if (string.IsNullOrEmpty(Disease))
                    _errorViewModel.AddError(nameof(Disease), "Заполните данное поле");
            }
        }

        private DateTime? _appointmentDateTime;

        public DateTime? AppointmentDateTime
        {
            get => _appointmentDateTime;
            set
            {
                if (Set(ref _appointmentDateTime, value)) return;
                _errorViewModel.ClearErrors(nameof(AppointmentDateTime));
                if (_appointmentDateTime == null)
                    _errorViewModel.AddError(nameof(AppointmentDateTime), "Выберите дату");
            }
        }

        public MessageViewModel MessageViewModel { get; set; }

        public string? ErrorMessage
        {
            set => MessageViewModel.Message = value;
        }

        public bool HasErrors => _errorViewModel.HasErrors;

        #endregion Propertis

        #region Commands

        public ICommand CreateNewAppointmentCommand { get; set; }

        #endregion Commands

        #region ctor

        public NewAppointmentViewModel(IHost host)
        {
            _errorViewModel = host.Services.GetRequiredService<ErrorViewModel>();
            MessageViewModel = host.Services.GetRequiredService<MessageViewModel>();
            CreateNewAppointmentCommand = host.Services.GetRequiredService<ICommandFactory>().CreateCommand(CommandType.CreateNewAppointment)!;
            using (var context = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new[] { "Default" }))
            {
                try
                {
                    _patientsComboBox = new ObservableCollection<Patient>(context.Patients!);
                    _doctorsComboBox = new ObservableCollection<Doctor>(context.Doctors!);
                }
                catch (ArgumentNullException)
                {
                    ErrorMessage = "Что-то пошло не так, проверьте подключение к базе данных";
                }
            }
        }

        #endregion ctor

        #region Methods

        public bool ArePropertiesNull() => !HasErrors
                                           && !string.IsNullOrEmpty(_disease)
                                           && _selectedDoctor != null
                                           && _selectedPatient != null
                                           && _appointmentDateTime != null;

        #endregion Methods
    }
}