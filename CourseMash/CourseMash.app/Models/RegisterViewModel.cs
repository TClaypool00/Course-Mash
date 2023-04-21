using System.ComponentModel.DataAnnotations;

namespace CourseMash.app.Models
{
    public class RegisterViewModel : UserViewModel
    {
        [Required]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Compare Password")]
        public string ConfirmPassword { get; set; }
    }
}
