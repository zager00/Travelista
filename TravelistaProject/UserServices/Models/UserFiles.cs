using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserServices.Models
{
    public class UserFiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserFilesID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        public long UserID { get; set; }
        [Required, MaxLength(200)]
        public string FilePath { get; set; }
        
    }
}
