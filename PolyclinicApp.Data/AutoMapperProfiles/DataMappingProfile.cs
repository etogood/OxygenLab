using AutoMapper;
using PolyclinicApp.Data.DataTransferObjects;
using PolyclinicApp.Data.Models;

namespace PolyclinicApp.Data.AutoMapperProfiles
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            #region Doctor

            CreateMap<Doctor, DoctorDTO>()
                    .ForMember(dto => dto.SpecializationName, conf => conf.MapFrom(s => s.Specialization.SpecializationName));
            CreateMap<DoctorDTO, Doctor>()
                .ForMember(s => s.Specialization.SpecializationName, conf => conf.MapFrom(dto => dto.SpecializationName));

            #endregion Doctor

            #region Patient

            CreateMap<Patient, PatientDTO>()
                   .ForMember(dto => dto.City, conf => conf.MapFrom(s => s.Address.City))
                   .ForMember(dto => dto.Street, conf => conf.MapFrom(s => s.Address.Street))
                   .ForMember(dto => dto.House, conf => conf.MapFrom(s => s.Address.House))
                   .ForMember(dto => dto.Other, conf => conf.MapFrom(s => s.Address.Other))

                   .ForMember(dto => dto.PassportCode, conf => conf.MapFrom(s => s.Passport.PassportCode))
                   .ForMember(dto => dto.PassportDate, conf => conf.MapFrom(s => s.Passport.PassportDate))
                   .ForMember(dto => dto.PassportExtraditionPlace,
                       conf => conf.MapFrom(s => s.Passport.PassportExtraditionPlace))
                   .ForMember(dto => dto.PassportNumber, conf => conf.MapFrom(s => s.Passport.PassportNumber))

                   .ForMember(dto => dto.MedicalInsuranceNumber,
                       conf => conf.MapFrom(s => s.MedicalInsurance.MedicalInsuranceNumber))
                   .ForMember(dto => dto.DateOfIssue, conf => conf.MapFrom(s => s.MedicalInsurance.DateOfIssue))
                   .ForMember(dto => dto.InsuranceCompanyName,
                       conf => conf.MapFrom(s => s.MedicalInsurance.InsuranceCompanyName));
            CreateMap<PatientDTO, Patient>()
                .ForMember(dto => dto.Address.City, conf => conf.MapFrom(s => s.City))
                .ForMember(dto => dto.Address.Street, conf => conf.MapFrom(s => s.Street))
                .ForMember(dto => dto.Address.House, conf => conf.MapFrom(s => s.House))
                .ForMember(dto => dto.Address.Other, conf => conf.MapFrom(s => s.Other))

                .ForMember(dto => dto.Passport.PassportCode, conf => conf.MapFrom(s => s.PassportCode))
                .ForMember(dto => dto.Passport.PassportDate, conf => conf.MapFrom(s => s.PassportDate))
                .ForMember(dto => dto.Passport.PassportExtraditionPlace,
                    conf => conf.MapFrom(s => s.PassportExtraditionPlace))
                .ForMember(dto => dto.Passport.PassportNumber, conf => conf.MapFrom(s => s.PassportNumber))

                .ForMember(dto => dto.MedicalInsurance.MedicalInsuranceNumber,
                    conf => conf.MapFrom(s => s.MedicalInsuranceNumber))
                .ForMember(dto => dto.MedicalInsurance.DateOfIssue, conf => conf.MapFrom(s => s.DateOfIssue))
                .ForMember(dto => dto.MedicalInsurance.InsuranceCompanyName,
                    conf => conf.MapFrom(s => s.InsuranceCompanyName));

            #endregion Patient

            #region MedicineCard

            CreateMap<MedicineCard, MedicineCardDTO>()
                .ForMember(dto => dto.PatientSurname, conf => conf.MapFrom(s => s.Patient.Surname))
                .ForMember(dto => dto.PatientFirstName, conf => conf.MapFrom(s => s.Patient.FirstName))
                .ForMember(dto => dto.PatientPatronymic, conf => conf.MapFrom(s => s.Patient.Patronymic))
                .ForMember(dto => dto.PatientFullName, conf => conf.MapFrom(s => s.Patient.FullName))

                .ForMember(dto => dto.DoctorSurname, conf => conf.MapFrom(s => s.Doctor.Surname))
                .ForMember(dto => dto.DoctorFirstName, conf => conf.MapFrom(s => s.Doctor.FirstName))
                .ForMember(dto => dto.DoctorPatronymic, conf => conf.MapFrom(s => s.Doctor.Patronymic))
                .ForMember(dto => dto.DoctorFullName, conf => conf.MapFrom(s => s.Doctor.FullName))

                .ForMember(dto => dto.City, conf => conf.MapFrom(s => s.Patient.Address.City))
                .ForMember(dto => dto.Street, conf => conf.MapFrom(s => s.Patient.Address.Street))
                .ForMember(dto => dto.House, conf => conf.MapFrom(s => s.Patient.Address.House))
                .ForMember(dto => dto.Other, conf => conf.MapFrom(s => s.Patient.Address.Other))

                .ForMember(dto => dto.PassportCode, conf => conf.MapFrom(s => s.Patient.Passport.PassportCode))
                .ForMember(dto => dto.PassportDate, conf => conf.MapFrom(s => s.Patient.Passport.PassportDate))
                .ForMember(dto => dto.PassportExtraditionPlace,
                    conf => conf.MapFrom(s => s.Patient.Passport.PassportExtraditionPlace))
                .ForMember(dto => dto.PassportNumber, conf => conf.MapFrom(s => s.Patient.Passport.PassportNumber))

                .ForMember(dto => dto.MedicalInsuranceNumber,
                    conf => conf.MapFrom(s => s.Patient.MedicalInsurance.MedicalInsuranceNumber))
                .ForMember(dto => dto.DateOfIssue, conf => conf.MapFrom(s => s.Patient.MedicalInsurance.DateOfIssue))
                .ForMember(dto => dto.InsuranceCompanyName,
                    conf => conf.MapFrom(s => s.Patient.MedicalInsurance.InsuranceCompanyName))


                .ForMember(dto => dto.SpecializationName,
                    conf => conf.MapFrom(s => s.Doctor.Specialization.SpecializationName));

            CreateMap<MedicineCardDTO, MedicineCard>()
                .ForMember(dto => dto.Patient.Surname, conf => conf.MapFrom(s => s.PatientSurname))
                .ForMember(dto => dto.Patient.FirstName, conf => conf.MapFrom(s => s.PatientFirstName))
                .ForMember(dto => dto.Patient.Patronymic, conf => conf.MapFrom(s => s.PatientPatronymic))
                .ForMember(dto => dto.Patient.FullName, conf => conf.MapFrom(s => s.PatientFullName))

                .ForMember(dto => dto.Doctor.Surname, conf => conf.MapFrom(s => s.DoctorSurname))
                .ForMember(dto => dto.Doctor.FirstName, conf => conf.MapFrom(s => s.DoctorFirstName))
                .ForMember(dto => dto.Doctor.Patronymic, conf => conf.MapFrom(s => s.DoctorPatronymic))
                .ForMember(dto => dto.Doctor.FullName, conf => conf.MapFrom(s => s.DoctorFullName))

                .ForMember(dto => dto.Patient.Address.City, conf => conf.MapFrom(s => s.City))
                .ForMember(dto => dto.Patient.Address.Street, conf => conf.MapFrom(s => s.Street))
                .ForMember(dto => dto.Patient.Address.House, conf => conf.MapFrom(s => s.House))
                .ForMember(dto => dto.Patient.Address.Other, conf => conf.MapFrom(s => s.Other))

                .ForMember(dto => dto.Patient.Passport.PassportCode, conf => conf.MapFrom(s => s.PassportCode))
                .ForMember(dto => dto.Patient.Passport.PassportDate, conf => conf.MapFrom(s => s.PassportDate))
                .ForMember(dto => dto.Patient.Passport.PassportExtraditionPlace,
                    conf => conf.MapFrom(s => s.PassportExtraditionPlace))
                .ForMember(dto => dto.Patient.Passport.PassportNumber, conf => conf.MapFrom(s => s.PassportNumber))

                .ForMember(dto => dto.Patient.MedicalInsurance.MedicalInsuranceNumber,
                    conf => conf.MapFrom(s => s.MedicalInsuranceNumber))
                .ForMember(dto => dto.Patient.MedicalInsurance.DateOfIssue, conf => conf.MapFrom(s => s.DateOfIssue))
                .ForMember(dto => dto.Patient.MedicalInsurance.InsuranceCompanyName,
                    conf => conf.MapFrom(s => s.InsuranceCompanyName))


                .ForMember(dto => dto.Doctor.Specialization.SpecializationName,
                    conf => conf.MapFrom(s => s.SpecializationName));
            #endregion MedicineCard
        }
    }
}