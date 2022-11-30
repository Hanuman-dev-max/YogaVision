

namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPosts;
    using YogaVision.Core.Models.Pagination;
    using YogaVision.Core.Models.TagBlogPosts;
    using YogaVision.Core.Models.Tags;

    public class BlogPostsController : BaseController
    {
        private readonly IBlogPostsService blogPostsService;
        private readonly ITagBlogPostsService tagBlogPostsService;

        public BlogPostsController(IBlogPostsService blogPostsService, ITagBlogPostsService tagBlogPostsService)
        {
            this.blogPostsService = blogPostsService;
            this.tagBlogPostsService = tagBlogPostsService;
        }

        public async Task<IActionResult> Index(
            int? sortId,
            int? pageNumber) // blogPostId
        {
            if (sortId != null)
            {
                var blogPost = await this.blogPostsService
                    .GetByIdAsync<BlogPostViewModel>(sortId.Value);
                if (blogPost == null)
                {
                    return new StatusCodeResult(404);
                }
            }

            this.ViewData["CurrentSort"] = sortId;

            int pageSize = PageSizesConstants.BlogPosts;
            var pageIndex = pageNumber ?? 1;

            var blogPosts = await this.blogPostsService
                .GetAllWithPagingAsync<BlogPostViewModel>(sortId, pageSize, pageIndex);
            var blogPostsList = blogPosts.ToList();

            var count = await this.blogPostsService.GetCountForPaginationAsync();

            var viewModel = new BlogPostsPaginatedListViewModel
            {
                BlogPosts = new PaginatedList<BlogPostViewModel>(blogPostsList, count, pageIndex, pageSize),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
          
            var blog = await blogPostsService.GetByIdAsync<BlogPostViewModel>(id);

            var tags = await tagBlogPostsService.GetTagByPostId(id);



            var model = new BlogDetailViewModel()
            {
                blog = blog,
                tags = tags
            };

            return View(model);

        
        }
    }
}
