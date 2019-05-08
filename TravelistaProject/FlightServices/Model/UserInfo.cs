using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightServices.Model
{
    public class UserInfo
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
