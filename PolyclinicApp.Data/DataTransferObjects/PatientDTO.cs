using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyclinicApp.Data.DataTransferObjects
{
    internal class PatientDTO
    {
        public int PatientId { get; set; }
        public int PassportId { get; set; }
        public int AddressId { get; set; }

        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string FullName => Surname + " " + FirstName + " " + Patronymic;

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
    }
}
