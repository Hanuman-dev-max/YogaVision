using YogaVision.Core.Models.Comment;

namespace YogaVision.Core.Models.BlogPost
{
   
    public class BlogDetailViewModel
    {
        public BlogPostViewModel blog { get; set; } = new BlogPostViewModel();
        public ICollection<string> tags { get; set; } = new List<string>();
        public IEnumerable<CommentViewModel> comments { get; set; } = new List<CommentViewModel>();
        public string UserComment { get; set; }

    }
}
