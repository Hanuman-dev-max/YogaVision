namespace YogaVision.Core.Models.Instructor
{

    using YogaVision.Core.Models.Pagination;
    public class InstructorsPaginatedListViewModel
    {
        public PaginatedList<InstructorViewModel>? Instructors { get; set; }

    }
}
