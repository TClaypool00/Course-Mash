using CourseMash.app.App_Code.BLL;
using CourseMash.app.App_Code.BOL;
using CourseMash.app.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseMash.app.App_Code.DAL
{
    public class UserService : IUserService
    {
        private readonly CourseMashContext _context;

        public UserService(CourseMashContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(RegisterViewModel model)
        {
            var dataModel = Mapper.MapUser(model);

            await _context.Users.AddAsync(dataModel);

            await SaveAsync();
        }

        public Task<UserViewModel> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserViewModel>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsByEmailAsync(string email)
        {
            return _context.Users.AnyAsync(u => u.Email == email);
        }

        public Task<bool> UserExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsByPhoneNumbAsync(string phoneNumb)
        {
            return _context.Users.AnyAsync(u => u.PhoneNumb == phoneNumb);
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
