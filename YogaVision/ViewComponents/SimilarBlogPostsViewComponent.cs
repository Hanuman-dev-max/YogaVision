

namespace YogaVision.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
  
      
    /// <summary>
    /// Displays similar blog posts based on similar tags of the BlogPost
    /// </summary>
    public class SimilarBlogPostsViewComponent : ViewComponent
    {
        private readonly IBlogPostService blogPostsService;

        /// <summary>
        /// Constructor for SimilarBlogPostsViewComponent
        /// </summary>
        /// <param name="blogPostsService"></param>
        public SimilarBlogPostsViewComponent(IBlogPostService blogPostsService)
        {
            this.blogPostsService = blogPostsService;
        }
        /// <summary>
        /// Method which invokes the ViewComponent in RazorViewPage
        /// </summary>
        /// <param name="tags">Tags, which will be searched</param>
        /// <param name="Id">The Id of the BlogPost </param>
        /// <returns></returns>
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
