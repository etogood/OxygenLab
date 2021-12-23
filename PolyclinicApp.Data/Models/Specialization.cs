using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PolyclinicApplication.Data.Models
{
    public class Specialization
    {
        [Key]
        public int SpecializationId { get; set; }

        public string SpecializationName { get; set; }
    }
}