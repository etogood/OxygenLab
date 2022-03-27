using System.ComponentModel.DataAnnotations;

namespace OxygenLab.Data.Models
{
    public class Reagent
    {
        [Key]
        public int ReagentId { get; set; }

        public string ReagentName { get; set; }
        public int Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfCreating { get; set; }

        public string? Description { get; set; }
    }
}