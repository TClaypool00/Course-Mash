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

            if (model.SchoolId is 0)
            {
                dataModel.School = null;
                dataModel.IsApproved = false;
            }
            else
            {
                dataModel.School = await _context.Schools.FirstOrDefaultAsync(s => s.SchoolId == model.SchoolId);
            }

            await _context.Users.AddAsync(dataModel);

            await SaveAsync();
        }

        public Task<UserViewModel> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> GetUserByEmailAsync(string email)
        {
            var dataUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return Mapper.MapUser(dataUser);
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

        public bool UserIsApprovedByApprovedByEmail(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email).Result.IsApproved;
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
