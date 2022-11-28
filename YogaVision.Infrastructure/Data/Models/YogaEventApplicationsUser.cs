

namespace YogaVision.Infrastructure.Data.Models
{

    using YogaVision.Infrastructure.Data.Common.Models;
    using YogaVision.Infrastructure.Data.Identity;
    public class YogaEventApplicationsUser : BaseDeletableModel<int>
    {
        public string YogaEventId { get; set; }
        public YogaEvent YogaEvent { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
