using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Model
{
    public class FlightModel
    {
        [Required]
        [StringLength(256)]
        public string Airline { get; set; }
        [Required]
        public DateTime DepatureDate { get; set; }
        [Required]
        public DateTime DepatureTime { get; set; }
        [Required]
        [StringLength(64)]
        public string DepartureTimeZone { get; set; }
        [Required]
        [StringLength(64)]
        public string DepatureCity { get; set; }
        [Required]
        [StringLength(64)]
        public string DepatureCountry { get; set; }
        [Required]
        [StringLength(64)]
        public string DepatureAirport { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        [Required]
        [StringLength(64)]
        public string ArrivalCountry { get; set; }
        [Required]
        [StringLength(64)]
        public string ArrivalCity { get; set; }
        [Required]
        [StringLength(64)]
        public string ArrivalAirport { get; set; }
        [Required]
        [StringLength(64)]
        public string ArrivalTimeZone { get; set; }
        [Required]
        public double Fair { get; set; }
        [Required]
        [StringLength(3)]
        public string Currency { get; set; }
        [Required]
        [StringLength(10)]
        public string FlightNumber { get; set; }
        [Required]
        [StringLength(10)]
        public string Class { get; set; }
        [Required]
        public bool Meal { get; set; }
        [Required]
        public bool InFlightEntertainment { get; set; }
        [Required]
        public bool Wifi { get; set; }

    }
}
