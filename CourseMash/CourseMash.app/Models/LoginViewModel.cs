using System.ComponentModel.DataAnnotations;

namespace CourseMash.app.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(255)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid a email address")]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
