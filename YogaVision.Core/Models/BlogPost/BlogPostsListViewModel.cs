
namespace YogaVision.Core.Models.BlogPost
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class BlogPostsListViewModel
    {
        public IEnumerable<BlogPostViewModel> BlogPosts { get; set; }
    }
}
