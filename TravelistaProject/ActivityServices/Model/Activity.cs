using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityServices.Model
{
    public class Activity

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ActivityID { get; set; }

        [ForeignKey("ActivityOrganiserID")]
        public ActivityOrganiser ActivityOrganiser { get; set; }

        public long ActivityOrganiserID { get; set; }
        [Required, MaxLength(100)]
        public string ActivityName { get; set; }
        [Required, MaxLength(100)]
        public string Type { get; set; }
        [Required, MaxLength(100)]
        public string Address { get; set; }
        [Required, MaxLength(100)]
        public string City { get; set; }
        [Required, MaxLength(100)]
        public string Country { get; set; }
        [Required, MaxLength(100)]
        public string State { get; set; }
        
        public string TermsCondition { get; set; }

        public string Remarks { get; set; }

    }
}
