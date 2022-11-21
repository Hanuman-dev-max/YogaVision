
namespace YogaVision.Core.Models.BlogPosts
{
    using YogaVision.Core.Models.Pagination;
    public class BlogPostsPaginatedListViewModel
    {
        public PaginatedList<BlogPostViewModel> BlogPosts { get; set; }
    }
}
