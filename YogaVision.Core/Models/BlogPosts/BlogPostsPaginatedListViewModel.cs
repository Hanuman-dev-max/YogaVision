
namespace YogaVision.Core.Models.BlogPosts
{
    using YogaVision.Core.Models.Pagination;
    public class BlogPostPaginatedListViewModel
    {
        public PaginatedList<BlogPostViewModel> BlogPosts { get; set; }
    }
}
