

namespace YogaVision.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
  
      
    /// <summary>
    /// Display similar blog posts based on similat tags
    /// </summary>
    public class SimilarBlogPostsViewComponent : ViewComponent
    {
        private readonly IBlogPostService blogPostsService;

        public SimilarBlogPostsViewComponent(IBlogPostService blogPostsService)
        {
            this.blogPostsService = blogPostsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<string> tags, int Id)
        {
            var viewModel = new BlogPostsListViewModel
            {
                BlogPosts = await this.blogPostsService.GetSimilarByTagAsync<BlogPostViewModel>(tags, Id),
            };

            return this.View(viewModel);
        }
    }
}
