using System.ComponentModel.DataAnnotations;

namespace PolyclinicApplication.Data.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int AddressId { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string House { get; set; }

        public string Other { get; set; }
    }
}