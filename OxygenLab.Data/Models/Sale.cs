using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OxygenLab.Data.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public int ReagentId { get; set; }
        public int ClientId { get; set; }
        public int Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfSale { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [ForeignKey("ReagentId")]
        public Reagent Reagent { get; set; }
    }
}