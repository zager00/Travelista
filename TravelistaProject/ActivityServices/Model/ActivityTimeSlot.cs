using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityServices.Model
{
    public class ActivityTimeSlot
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ActivityTimeSlotID { get; set; }

        [ForeignKey("ActivityID")]
        public Activity Activity { get; set; }
        public long ActivityID { get; set; }
        [Required, MaxLength(100)]
        public DateTime? StartTime { get; set; }
        [Required, MaxLength(100)]
        public DateTime? EndTime{ get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Currency { get; set; }
       
    }
}
