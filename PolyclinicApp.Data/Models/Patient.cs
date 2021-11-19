using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PolyclinicApplication.Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public int PassportId { get; set; }

        public int AddressId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public int MedicalInsuranceId { get; set; }

        public string InsuranceIndividualPersonalAccountNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("PassportId")]
        public Passport Passport { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [ForeignKey("MedicalInsuranceId")]
        public MedicalInsurance MedicalInsurance { get; set; }
    }
}