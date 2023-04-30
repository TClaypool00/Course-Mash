using CourseMash.app.Models;
using CourseMash.app.Models.PostModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseMash.app.App_Code.BLL
{
    public interface ISchoolService
    {
        public Task<List<SchoolViewModel>> GetSchoolsAsync();

        public Task<List<SelectListItem>> GetSchoolDropDown();

        public Task<SchoolViewModel> GetSchoolAsync(int id);

        public Task<SchoolViewModel> AddSchoolAsync(PostSchoolViewModel school);

        public Task<SchoolViewModel> UpdateSchoolAsync(SchoolViewModel school);

        public Task<bool> SchoolExistByIdAsync(int id);

        public Task<bool> SchoolExistByNameAsync(string name, int? id = null);
    }
}
