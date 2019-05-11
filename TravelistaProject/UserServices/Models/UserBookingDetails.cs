using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserServices.Models
{
    public class UserBookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserBookingDetailsID{ get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        public long UserID { get; set; }
        [Required, MaxLength(100)]
        public string BookingID { get; set; }
        [Required, MaxLength(100)]
        public string TranscationID { get; set; }
        [Required, MaxLength(100)]
        public string Status { get; set; }

    }
}
