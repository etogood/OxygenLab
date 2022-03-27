using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OxygenLab.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Login { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        [NotMapped]
        public string FullName => Surname + ' ' + Name + ' ' + Patronymic;

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Post { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}