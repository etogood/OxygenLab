using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PolyclinicApplication.Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public int SpecializationId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public string FullName => Surname + " " + FirstName + " " + Patronymic;

            [ForeignKey("SpecializationId")]
        public Specialization Specialization { get; set; }
    }
}