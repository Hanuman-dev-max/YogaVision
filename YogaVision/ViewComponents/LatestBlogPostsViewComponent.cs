
namespace YogaVision.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    /// <summary>
    /// Display the latest blog posts
    /// </summary>
    public class LatestBlogPostsViewComponent : ViewComponent
    {
        private readonly IBlogPostService blogPostsService;
        /// <summary>
        /// Constructor for LatestBlogPostsViewComponent
        /// </summary>
        /// <param name="blogPostsService">Interface for IBlogPostService </param>
        public LatestBlogPostsViewComponent(IBlogPostService blogPostsService)
        {
            this.blogPostsService = blogPostsService;
        }
        /// <summary>
        /// Method which invokes the ViewComponent in the RazorViewPage
        /// </summary>
        /// <param name="count">The number of BlogPosts for displaying</param>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(int? count)
        {
            var viewModel = new BlogPostsListViewModel
            {
                BlogPosts = await this.blogPostsService.GetAllAsync<BlogPostViewModel>(count),
            };

            return this.View(viewModel);
        }
    }
}
