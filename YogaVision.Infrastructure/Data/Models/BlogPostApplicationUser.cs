using YogaVision.Infrastructure.Data.Common.Models;
using YogaVision.Infrastructure.Data.Identity;

namespace YogaVision.Infrastructure.Data.Models
{
    public class BlogPostApplicationUser : BaseDeletableModel<int>
    {
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
