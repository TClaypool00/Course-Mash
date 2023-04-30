using System.ComponentModel.DataAnnotations;

namespace CourseMash.app.Models.PostModel
{
    public class PostSchoolViewModel
    {
        [Display(Name = "School name")]
        [Required(ErrorMessage = "School name is required")]
        [MaxLength(255, ErrorMessage = "School name has max length of 255")]
        public string SchoolName { get; set; }
    }
}
