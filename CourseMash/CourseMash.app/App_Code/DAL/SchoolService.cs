using CourseMash.app.App_Code.BLL;
using CourseMash.app.App_Code.BOL;
using CourseMash.app.Models;
using CourseMash.app.Models.PostModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourseMash.app.App_Code.DAL
{
    public class SchoolService : ISchoolService
    {
        private readonly CourseMashContext _context;

        public SchoolService(CourseMashContext context)
        {
            _context = context;
        }

        public async Task<SchoolViewModel> AddSchoolAsync(PostSchoolViewModel school)
        {
            var dataSchool = Mapper.MapSchool(school);

            await _context.Schools.AddAsync(dataSchool);

            await SaveAsync();

            if (dataSchool.SchoolId == 0)
            {
                throw new ArgumentException("School could not be added");
            }

            return Mapper.MapSchool(dataSchool);
        }

        public Task<SchoolViewModel> GetSchoolAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SelectListItem>> GetSchoolDropDown()
        {
            var schools = await GetDataSchools();
            var dropDown = new List<SelectListItem>();

            if (schools.Count > 0)
            {                
                SelectListItem dropDownItem;

                dropDownItem = new SelectListItem
                {
                    Text = "Please select a school...",
                    Value = "",
                    Selected = true
                };

                dropDown.Add(dropDownItem);

                dropDownItem = new SelectListItem
                {
                    Text = "No School",
                    Value = "0",
                    Selected = false,
                };

                dropDown.Add(dropDownItem);                

                for (int i = 0; i < schools.Count; i++)
                {
                    var school = schools[i];
                    dropDownItem = new SelectListItem
                    {
                        Text = school.SchoolName,
                        Value = school.SchoolId.ToString(),
                        Selected = false
                    };

                    dropDown.Add(dropDownItem);
                    
                }
            }

            return dropDown;
        }

        public async Task<List<SchoolViewModel>> GetSchoolsAsync()
        {
            var dataSchools = await GetDataSchools();
            var schools = new List<SchoolViewModel>();

            if (dataSchools.Count > 0)
            {
                for (int i = 0; i < dataSchools.Count; i++)
                {
                    schools.Add(Mapper.MapSchool(dataSchools[i]));
                }
            }

            return schools;
        }

        public Task<bool> SchoolExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SchoolExistByNameAsync(string name, int? id = null)
        {
            if (id == null)
            {
                return _context.Schools.AnyAsync(s => s.SchoolName == name);
            }

            return _context.Schools.AnyAsync(s => s.SchoolName == name && s.SchoolId == id);
        }

        public Task<SchoolViewModel> UpdateSchoolAsync(SchoolViewModel school)
        {
            throw new NotImplementedException();
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private Task<List<School>> GetDataSchools()
        {
            return _context.Schools.ToListAsync();
        }
    }
}
