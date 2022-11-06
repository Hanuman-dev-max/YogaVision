
namespace YogaVision.Core.Models.BlogPosts
{
    using YogaVision.Infrastructure.Data.Common.Mapping;
    using YogaVision.Infrastructure.Data.Models;
    public class BlogPostsListViewModel
    {
        public IEnumerable<BlogPostViewModel> BlogPosts { get; set; }
    }
}
