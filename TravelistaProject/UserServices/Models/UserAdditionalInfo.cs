using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserServices.Models
{
    public class UserAdditionalInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserAdditionalInfoID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }            
        public long UserID { get; set; }
        [Required, MaxLength(100)]
        public string HomeAddress { get; set; }
        [Required, MaxLength(100)]
        public string City { get; set; }
        [Required, MaxLength(100)]
        public string State { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [Required, MaxLength(100)]
        public string PassportNo { get; set; }
      
    }
}
