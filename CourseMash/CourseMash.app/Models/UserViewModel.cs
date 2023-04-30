using System.ComponentModel.DataAnnotations;

namespace CourseMash.app.Models
{
    public class UserViewModel : LoginViewModel
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name ="Last name")]
        public string LastName { get; set; }        

        [Required]
        [MaxLength(10)]
        [Display(Name = "Phone number")]
        [RegularExpression("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumb { get; set; }

        [Display(Name = "Is Admin?")]
        public bool IsAdmin { get; set; }
        
        public bool IsApproved { get; set; }

        public int? SchoolId { get; set; }        
    }
}
