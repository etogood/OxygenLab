using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OxygenLab.Data.DataAccess;
using OxygenLab.WPF.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using OxygenLab.Data.Models;
using OxygenLab.WPF.Stores.Login;

namespace OxygenLab.WPF.ViewModels
{
    internal class PersonalAccountViewModel : ViewModel
    {
        

        #region Fields

        private readonly ErrorViewModel _errorViewModel;
        private readonly ILoginStore _loginStore;

        #endregion Fields

        #region Propertis

        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => Set(ref _dateOfBirth, value);
        }


        private string _phone;

        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        private string _post;

        public string Post
        {
            get => _post;
            set => Set(ref _post, value);
        }


        private ObservableCollection<Experiment> _experimentsTable;

        public ObservableCollection<Experiment> ExperimentsTable
        {
            get => _experimentsTable;
            set => Set(ref _experimentsTable, value);
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

        public PersonalAccountViewModel(IHost host)
        {
            _errorViewModel = host.Services.GetRequiredService<ErrorViewModel>();
            MessageViewModel = host.Services.GetRequiredService<MessageViewModel>();
            _loginStore = host.Services.GetRequiredService<ILoginStore>();
            
            using (var context = host.Services.GetRequiredService<AppDbContextFactory>().CreateDbContext(new[] { "Default" }))
            {
                
                _experimentsTable = new ObservableCollection<Experiment>(context.Experiments
                    .Include(x => x.User)
                    .Where(x => x.User == _loginStore.CurrentUser));
                _name = _loginStore.CurrentUser.FullName;
                _dateOfBirth = _loginStore.CurrentUser.DateOfBirth;
                _phone = _loginStore.CurrentUser.PhoneNumber;
                _post = _loginStore.CurrentUser.Post;
            }
        }

        #endregion ctor

        #region Methods

        //public bool ArePropertiesNull() => !HasErrors&& !string.IsNullOrEmpty(_disease)&& _selectedDoctor != null&& _selectedPatient != null&& _appointmentDateTime != null;

        #endregion Methods
    }
}