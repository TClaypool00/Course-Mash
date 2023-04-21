using CourseMash.app.App_Code.BOL;
using CourseMash.app.Models;

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
    }
}
