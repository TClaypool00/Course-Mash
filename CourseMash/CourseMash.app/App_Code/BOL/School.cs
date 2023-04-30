using System.ComponentModel.DataAnnotations;

namespace CourseMash.app.App_Code.BOL
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }

        [Required]
        [MaxLength(255)]
        public string SchoolName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public List<User> Users { get; set; }
    }
}
