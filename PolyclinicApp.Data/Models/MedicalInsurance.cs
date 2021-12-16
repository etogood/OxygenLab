using System;
using System.ComponentModel.DataAnnotations;

namespace PolyclinicApplication.Data.Models
{
    public class MedicalInsurance
    {
        [Key]
        [Required]
        public int MedicalInsuranceId { get; set; }

        [Required]
        public long? MedicalInsuranceNumber { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public string InsuranceCompanyName { get; set; }
    }
}