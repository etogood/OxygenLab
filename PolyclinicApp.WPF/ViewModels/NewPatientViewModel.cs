using System;
using PolyclinicApp.WPF.Commands;
using PolyclinicApp.WPF.Factories.ViewModel;
using PolyclinicApp.WPF.Stores.Navigation;
using PolyclinicApp.WPF.ViewModels.Base;
using System.Windows.Input;
using Microsoft.Extensions.Hosting;

namespace PolyclinicApp.WPF.ViewModels
{
    internal class NewPatientViewModel : ViewModel
    {

        #region Fields

        private readonly ErrorViewModel _errorViewModel;

        #endregion

        #region Commands
        public ICommand? InformationViewCommand { get; }
        public ICommand? CreateNewPatientCommand { get; }
        #endregion

        #region Properties

        #region PersonalInfo
        private string _surname;

        public string Surname
        {
            get => _surname;
            set
            {
                if (!Set(ref _surname, value)) return;
                _errorViewModel.ClearErrors(nameof(Surname));
                if (string.IsNullOrEmpty(Surname))
                    _errorViewModel.AddError(nameof(Surname), "Заполните поле");
            }
        }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!Set(ref _firstName, value)) return;
                _errorViewModel.ClearErrors(nameof(FirstName));
                if (string.IsNullOrEmpty(FirstName))
                    _errorViewModel.AddError(nameof(FirstName), "Заполните поле");
            }
        }


        private string _patronymic;

        public string Patronymic
        {
            get => _patronymic;
            set
            {
                if (!Set(ref _patronymic, value)) return;
                _errorViewModel.ClearErrors(nameof(Patronymic));
                if (string.IsNullOrEmpty(Patronymic))
                    _errorViewModel.AddError(nameof(Patronymic), "Заполните поле");
            }
        }

        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (!Set(ref _dateOfBirth, value)) return;
                _errorViewModel.ClearErrors(nameof(DateOfBirth));
                if (DateOfBirth == DateTime.MinValue)
                    _errorViewModel.AddError(nameof(DateOfBirth), "Заполните поле");
            }
        }
        #endregion

        #region Address

        private string _addressCity;

        public string AddressCity
        {
            get => _addressCity;
            set
            {
                if (!Set(ref _addressCity, value)) return;
                _errorViewModel.ClearErrors(nameof(AddressCity));
                if (string.IsNullOrEmpty(AddressCity))
                    _errorViewModel.AddError(nameof(AddressCity), "Заполните поле");
            }
        }

        private string _addressStreet;

        public string AddressStreet
        {
            get => _addressStreet;
            set
            {
                if (!Set(ref _addressStreet, value)) return;
                _errorViewModel.ClearErrors(nameof(AddressStreet));
                if (string.IsNullOrEmpty(AddressStreet))
                    _errorViewModel.AddError(nameof(AddressStreet), "Заполните поле");
            }
        }

        private string _addressHouse;   

        public string AddressHouse
        {
            get => _addressHouse;
            set
            {
                if (!Set(ref _addressHouse, value)) return;
                _errorViewModel.ClearErrors(nameof(AddressHouse));
                if (string.IsNullOrEmpty(AddressHouse))
                    _errorViewModel.AddError(nameof(AddressHouse), "Заполните поле");
            }
        }

        private string _addressOther;

        public string AddressOther
        {
            get => _addressOther;
            set
            {
                if (!Set(ref _addressOther, value)) return;
                _errorViewModel.ClearErrors(nameof(AddressOther));
                if (string.IsNullOrEmpty(AddressOther))
                    _errorViewModel.AddError(nameof(AddressOther), "Заполните поле");
            }
        }


        #endregion

        #region Passport

        private string _passportNumber;

        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                if (!Set(ref _passportNumber, value)) return;
                _errorViewModel.ClearErrors(nameof(PassportNumber));
                if (string.IsNullOrEmpty(PassportNumber))
                    _errorViewModel.AddError(nameof(PassportNumber), "Заполните поле");
            }
        }

        private string _passportExtraditionPlace;

        public string PassportExtraditionPlace
        {
            get => _passportExtraditionPlace;
            set
            {
                if (!Set(ref _passportExtraditionPlace, value)) return;
                _errorViewModel.ClearErrors(nameof(PassportExtraditionPlace));
                if (string.IsNullOrEmpty(PassportExtraditionPlace))
                    _errorViewModel.AddError(nameof(PassportExtraditionPlace), "Заполните поле");
            }
        }

        private DateTime _passportDate;

        public DateTime PassportDate
        {
            get => _passportDate;
            set
            {
                if (!Set(ref _passportDate, value)) return;
                _errorViewModel.ClearErrors(nameof(PassportDate));
                if (PassportDate == DateTime.MinValue)
                    _errorViewModel.AddError(nameof(PassportDate), "Заполните поле");
            }
        }

        private string _passportCode;

        public string PassportCode
        {
            get => _passportCode;
            set
            {
                if (!Set(ref _passportCode, value)) return;
                _errorViewModel.ClearErrors(nameof(PassportCode));
                if (string.IsNullOrEmpty(PassportCode))
                    _errorViewModel.AddError(nameof(PassportCode), "Заполните поле");
            }
        }



        #endregion

        #region Insurances

        private long? _medicalInsuranceNumber;

        public long? MedicalInsuranceNumber
        {
            get => _medicalInsuranceNumber;
            set
            {
                if (!Set(ref _medicalInsuranceNumber, value)) return;
                _errorViewModel.ClearErrors(nameof(MedicalInsuranceNumber));
                if(MedicalInsuranceNumber == null)
                    _errorViewModel.AddError(nameof(MedicalInsuranceNumber), "Заполните поле");

            }
        }

        private DateTime _dateOfIssue;

        public DateTime DateOfIssue
        {
            get => _dateOfIssue;
            set
            {
                if (!Set(ref _dateOfIssue, value)) return;
                _errorViewModel.ClearErrors(nameof(DateOfIssue));
                if (DateOfIssue == DateTime.MinValue)
                    _errorViewModel.AddError(nameof(DateOfIssue), "Заполните поле");
            }
        }

        private string _insuranceCompanyName;

        public string InsuranceCompanyName
        {
            get => _insuranceCompanyName;
            set
            {
                if (!Set(ref _insuranceCompanyName, value)) return;
                _errorViewModel.ClearErrors(nameof(InsuranceCompanyName));
                if (string.IsNullOrEmpty(InsuranceCompanyName))
                    _errorViewModel.AddError(nameof(InsuranceCompanyName), "Заполните поле");
            }
        }

        private string _iipan;

        public string Iipan
        {
            get => _iipan;
            set
            {
                if (!Set(ref _iipan, value)) return;
                _errorViewModel.ClearErrors(nameof(Iipan));
                if (string.IsNullOrEmpty(Iipan))
                    _errorViewModel.AddError(nameof(Iipan), "Заполните поле");
            }
        }


        #endregion

        public MessageViewModel MessageViewModel { get; }
        public string? ErrorMessage
        {
            set => MessageViewModel.Message = value;
        }
        public bool HasErrors => _errorViewModel.HasErrors;

        #endregion

        #region Ctor
        public NewPatientViewModel(INavigationStore navigationStore, IViewModelFactory viewModelFactory, ErrorViewModel errorViewModel, IHost host)
        {
            _errorViewModel = errorViewModel;
            InformationViewCommand = new InformationViewCommand(navigationStore, viewModelFactory, host);
            CreateNewPatientCommand = new CreateNewPatientCommand(this);
        }
        #endregion

        #region Methods

        public bool ArePropertiesNull() => string.IsNullOrEmpty(_surname)
                                           || string.IsNullOrEmpty(_firstName)
                                           || string.IsNullOrEmpty(_patronymic)
                                           || _dateOfBirth == DateTime.MinValue
                                           || string.IsNullOrEmpty(_addressCity)
                                           || string.IsNullOrEmpty(_addressHouse)
                                           || string.IsNullOrEmpty(_addressStreet)
                                           || string.IsNullOrEmpty(_passportNumber)
                                           || string.IsNullOrEmpty(_passportExtraditionPlace)
                                           || string.IsNullOrEmpty(_passportCode)
                                           || _passportDate == DateTime.MinValue
                                           || _medicalInsuranceNumber != null
                                           || string.IsNullOrEmpty(_insuranceCompanyName)
                                           || string.IsNullOrEmpty(_iipan)
                                           || _dateOfIssue == DateTime.MinValue;

        #endregion
    }
}