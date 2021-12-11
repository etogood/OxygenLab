using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PolyclinicApplication.Data.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public int DoctorId { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Monday { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Tuesday { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Wednesday { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Thursday { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Friday { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Saturday { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Sunday { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}