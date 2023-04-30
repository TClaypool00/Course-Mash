using CourseMash.app.App_Code.BLL;
using CourseMash.app.Models.CombinedViewModels;
using CourseMash.app.Models.PostModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseMash.app.Controllers
{
    [Authorize(Roles ="Admin")]
    public class SchoolsController : Controller
    {
        private readonly ISchoolService _service;

        public SchoolsController(ISchoolService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var schoolModel = new SchoolsViewModelWithPost
            {
                Schools = await _service.GetSchoolsAsync(),
                PostSchoolViewModel = new PostSchoolViewModel()
            };

            return View(schoolModel);
        }

        [HttpPost]
        public async Task<ActionResult> PostSchoolAsync(PostSchoolViewModel model)
        {
            try
            {
                if (await _service.SchoolExistByNameAsync(model.SchoolName))
                {
                    ModelState.AddModelError("SchoolName", $"School with a name of {model.SchoolName} already exists");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var school = await _service.AddSchoolAsync(model);

                return Ok(school);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
