
namespace YogaVision.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;

    public class LatestBlogPostsViewComponent : ViewComponent
    {
        private readonly IBlogPostService blogPostsService;

        public LatestBlogPostsViewComponent(IBlogPostService blogPostsService)
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
