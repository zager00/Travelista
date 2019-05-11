using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserServices.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        [Required,MaxLength(200)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        public DateTime? DOB { get; set; }
        [MaxLength(20)]
        public string Gender { get; set; }
        public string ImageURL { get; set; }
       
    }
}
