using Microsoft.AspNetCore.Mvc.Rendering;
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

        public List<SelectListItem> SchoolDropDown { get; set; }

        public bool AdminSchoolNotNull()
        {
            if (IsAdmin && SchoolId is not 0)
            {
                SchoolId = null;

                return false;
            }

            return true;
        }

        public bool NotAdminSchoolNull()
        {
            if (!IsAdmin && SchoolId is null)
            {
                return false;
            }

            return true;
        }

        public string NotAdminErrorMessage { get; } = "Users must be assigned to assinged to a school.";

        public string AdminErrorMessage { get; } = "Admins cannot be assigned to a school.";
    }
}
