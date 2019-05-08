using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices
{
    public class FlightsBookingUrl
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
