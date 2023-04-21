using CourseMash.app.Models;

namespace CourseMash.app.App_Code.BLL
{
    public interface IUserService
    {
        public Task<List<UserViewModel>> GetUsersAsync();

        public Task<UserViewModel> GetUserAsync(int id);

        public Task<UserViewModel> GetUserByEmailAsync(string email);

        public Task AddUserAsync(RegisterViewModel model);

        public Task UpdateUserAsync(UserViewModel model);

        public Task<bool> UserExistsById(int id);

        public Task<bool> UserExistsByEmailAsync(string email);

        public Task<bool> UserExistsByPhoneNumbAsync(string phoneNumb);
    }
}
