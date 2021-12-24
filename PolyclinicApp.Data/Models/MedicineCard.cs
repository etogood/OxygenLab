using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PolyclinicApp.Data.Models;

#nullable disable

namespace PolyclinicApp.Data.Models
{
    public class MedicineCard
    {
        [Key]
        public int MedicineCardId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Disease { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfDiagnosis { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}