using CourseMash.app.Models.PostModel;
using System.ComponentModel.DataAnnotations;

namespace CourseMash.app.Models
{
    public class SchoolViewModel : PostSchoolViewModel
    {
        public int SchoolId { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }
    }
}
