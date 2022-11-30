



namespace YogaVision.Core.Models.BlogPosts
{
    using YogaVision.Core.Models.TagBlogPosts;
    public class BlogDetailViewModel
    {
        public BlogPostViewModel blog = new BlogPostViewModel();
        public List<string> tags = new List<string>();
    }
}
