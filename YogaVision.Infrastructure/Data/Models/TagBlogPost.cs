namespace YogaVision.Infrastructure.Data.Models
{

    using YogaVision.Infrastructure.Data.Common.Models;
    public class TagBlogPost : BaseDeletableModel<int>
    {
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
