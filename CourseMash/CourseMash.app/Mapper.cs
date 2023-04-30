using CourseMash.app.App_Code.BOL;
using CourseMash.app.Models;
using CourseMash.app.Models.PostModel;

namespace CourseMash.app
{
    public class Mapper
    {
        public static User MapUser(RegisterViewModel model)
        {
            return new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                IsAdmin = model.IsAdmin,
                PhoneNumb = model.PhoneNumb
            };
        }

        public static UserViewModel MapUser(User user)
        {
            return new UserViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                IsAdmin = user.IsAdmin,
                PhoneNumb = user.PhoneNumb,
            };
        }

        public static SchoolViewModel MapSchool(School school)
        {
            return new SchoolViewModel
            {
                SchoolId = school.SchoolId,
                SchoolName = school.SchoolName,
                IsActive = school.IsActive
            };
        }

        public static School MapSchool(PostSchoolViewModel school)
        {
            return new School
            {
                IsActive = true,
                SchoolName = school.SchoolName
            };
        }
    }
}
