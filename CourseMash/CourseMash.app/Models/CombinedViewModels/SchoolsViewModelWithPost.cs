using CourseMash.app.Models.PostModel;

namespace CourseMash.app.Models.CombinedViewModels
{
    public class SchoolsViewModelWithPost
    {
        public List<SchoolViewModel> Schools { get; set; }

        public PostSchoolViewModel PostSchoolViewModel { get; set; }
    }
}
