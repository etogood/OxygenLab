using System.ComponentModel.DataAnnotations.Schema;

namespace PolyclinicApplication.Data.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}