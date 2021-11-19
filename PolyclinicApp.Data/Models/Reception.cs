using System;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PolyclinicApplication.Data.Models
{
    public class Reception
    {
        public int ReceptionId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime DateOfAssignment { get; set; }

        public string HealthComplaint { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}