using System.ComponentModel.DataAnnotations;

namespace OxygenLab.Data.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string OrganizationName { get; set; }
        public string ContactPerson { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}