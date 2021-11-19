using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PolyclinicApplication.Data.Models
{
    public class Passport
    {
        public int PassportId { get; set; }

        public string PassportNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime PassportDate { get; set; }

        public string PassportExtraditionPlace { get; set; }

        public string PassportCode { get; set; }

    }
}