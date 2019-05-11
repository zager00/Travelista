using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityServices.Model
{
    public class ActivityOrganiser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ActivityOrganiserID { get; set; }

        [Required, MaxLength(200)]
        public String Name { get; set; }

       
    }
}
