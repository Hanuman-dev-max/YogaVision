namespace YogaVision.Core.Models.BlogPost
{
   
    public class BlogDetailViewModel
    {
        public BlogPostViewModel blog = new BlogPostViewModel();
        public ICollection<string> tags = new List<string>();
    }
}
