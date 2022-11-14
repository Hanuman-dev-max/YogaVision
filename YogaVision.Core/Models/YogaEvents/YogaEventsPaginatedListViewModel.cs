

using YogaVision.Core.Models.Instructors;
using YogaVision.Core.Models.Pagination;

namespace YogaVision.Core.Models.YogaEvents
{
    public class YogaEventsPaginatedListViewModel
    {
        public PaginatedList<YogaEventViewModel> YogaEvents { get; set; }
    }
}
