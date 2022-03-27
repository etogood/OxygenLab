using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OxygenLab.Data.Models
{
    public class Experiment
    {
        [Key]
        public int ExperimentId { get; set; }

        public string ExperimentName { get; set; }
        public string DateOfExperiment { get; set; }
        public int ExecutivePersonId { get; set; }
        public string? Description { get; set; }

        [ForeignKey("ExecutivePersonId")]
        public User User { get; set; }
    }
}