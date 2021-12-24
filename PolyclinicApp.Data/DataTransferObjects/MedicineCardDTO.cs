using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyclinicApp.Data.DataTransferObjects
{
    internal class MedicineCardDTO
    {
        public int MedicineCardId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Disease { get; set; }
        public DateTime? DateOfDiagnosis { get; set; }


        public int PassportId { get; set; }
        public int AddressId { get; set; }
        public string PatientSurname { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientPatronymic { get; set; }
        public string PatientFullName => PatientSurname + " " + PatientFirstName + " " + PatientPatronymic;
        public int MedicalInsuranceId { get; set; }
        public string InsuranceIndividualPersonalAccountNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string PassportNumber { get; set; }
        public DateTime PassportDate { get; set; }
        public string PassportExtraditionPlace { get; set; }
        public string PassportCode { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Other { get; set; }

        public long? MedicalInsuranceNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string InsuranceCompanyName { get; set; }


        public int SpecializationId { get; set; }

        public string DoctorSurname { get; set; }

        public string DoctorFirstName { get; set; }

        public string DoctorPatronymic { get; set; }

        public string DoctorFullName => DoctorSurname + " " + DoctorFirstName + " " + DoctorPatronymic;

        public string SpecializationName { get; set; }
    }
}
