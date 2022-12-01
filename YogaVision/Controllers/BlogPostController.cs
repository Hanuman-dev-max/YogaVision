

namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
 
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    using YogaVision.Core.Models.Pagination;
    

    public class BlogPostController : BaseController
    {
        private readonly IBlogPostService blogPostService;
        private readonly ITagBlogPostService tagBlogPostService;

        public BlogPostController(IBlogPostService blogPostService, ITagBlogPostService tagBlogPostService)
        {
            this.blogPostService = blogPostService;
            this.tagBlogPostService = tagBlogPostService;
        }

        public async Task<IActionResult> Index(
            int? sortId,
            int? pageNumber) // blogPostId
        {
            if (sortId != null)
            {
                var blogPost = await this.blogPostService
                    .GetByIdAsync<BlogPostViewModel>(sortId.Value);
                if (blogPost == null)
                {
                    return new StatusCodeResult(404);
                }
            }

            this.ViewData["CurrentSort"] = sortId;

            int pageSize = PageSizesConstants.BlogPosts;
            var pageIndex = pageNumber ?? 1;

            var blogPosts = await this.blogPostService
                .GetAllWithPagingAsync<BlogPostViewModel>(sortId, pageSize, pageIndex);
            var blogPostsList = blogPosts.ToList();

            var count = await this.blogPostService.GetCountForPaginationAsync();

            var viewModel = new BlogPostsPaginatedListViewModel
            {
                BlogPosts = new PaginatedList<BlogPostViewModel>(blogPostsList, count, pageIndex, pageSize),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
          
            var blog = await blogPostService.GetByIdAsync<BlogPostViewModel>(id);

            var tags = await tagBlogPostService.GetTagByPostId(id);



            var model = new BlogDetailViewModel()
            {
                blog = blog,
                tags = tags
            };

            return View(model);

        
        }
    }
}
