namespace YogaVision.Core.Models.YogaEvent
{
    using YogaVision.Core.Models.Instructor;
    using YogaVision.Core.Models.Pagination;
    public class YogaEventsPaginatedListViewModel
    {
        public PaginatedList<YogaEventViewModel>? YogaEvents { get; set; }
    }
}
