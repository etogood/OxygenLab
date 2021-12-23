using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PolyclinicApplication.Data.Models;

#nullable disable

namespace PolyclinicApp.Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public int SpecializationId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        [NotMapped]
        public string FullName => Surname + " " + FirstName + " " + Patronymic;

        [ForeignKey("SpecializationId")]
        public Specialization Specialization { get; set; }
    }
}