

namespace YogaVision.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPosts;
  
      

    public class SimilarBlogPostsViewComponent : ViewComponent
    {
        private readonly IBlogPostsService blogPostsService;

        public SimilarBlogPostsViewComponent(IBlogPostsService blogPostsService)
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
