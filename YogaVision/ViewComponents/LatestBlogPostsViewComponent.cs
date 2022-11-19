
namespace YogaVision.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPosts;

    public class LatestBlogPostsViewComponent : ViewComponent
    {
        private readonly IBlogPostsService blogPostsService;

        public LatestBlogPostsViewComponent(IBlogPostsService blogPostsService)
        {
            this.blogPostsService = blogPostsService;
        }

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
