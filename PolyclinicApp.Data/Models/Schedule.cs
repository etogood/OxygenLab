using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PolyclinicApp.Data.Models;

#nullable disable

namespace PolyclinicApplication.Data.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public int DoctorId { get; set; }

        [DataType(DataType.Time)]
        public string Monday { get; set; }

        [DataType(DataType.Time)]
        public string Tuesday { get; set; }

        [DataType(DataType.Time)]
        public string Wednesday { get; set; }

        [DataType(DataType.Time)]
        public string Thursday { get; set; }

        [DataType(DataType.Time)]
        public string Friday { get; set; }

        [DataType(DataType.Time)]
        public string Saturday { get; set; }

        [DataType(DataType.Time)]
        public string Sunday { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}