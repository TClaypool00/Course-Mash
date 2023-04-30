using System.ComponentModel.DataAnnotations;

namespace CourseMash.app.App_Code.BOL
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumb { get; set; }

        public bool IsAdmin { get; set; }

        public School School { get; set; }

        public bool IsApproved { get; set; }
    }
}
