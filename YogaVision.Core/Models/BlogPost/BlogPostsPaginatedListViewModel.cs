
namespace YogaVision.Core.Models.BlogPost
{
    using YogaVision.Core.Models.Pagination;
    public class BlogPostsPaginatedListViewModel
    {
        public PaginatedList<BlogPostViewModel> BlogPosts { get; set; }
    }
}
