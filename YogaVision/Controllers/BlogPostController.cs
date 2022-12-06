

namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
 
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    using YogaVision.Core.Models.Pagination;
    
    /// <summary>
    /// Controller which handles BlogPost model 
    /// </summary>
    public class BlogPostController : BaseController
    {
        private readonly IBlogPostService blogPostService;
        private readonly ITagBlogPostService tagBlogPostService;
        /// <summary>
        /// Constructor for BlogPostController
        /// </summary>
        /// <param name="blogPostService"></param>
        /// <param name="tagBlogPostService"></param>
        public BlogPostController(IBlogPostService blogPostService, ITagBlogPostService tagBlogPostService)
        {
            this.blogPostService = blogPostService;
            this.tagBlogPostService = tagBlogPostService;
        }
        /// <summary>
        /// Display Index View
        /// </summary>
        /// <param name="sortId">The Id of BlogPost</param>
        /// <param name="pageNumber">The number of page</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(
            int? sortId,
            int? pageNumber) 
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
        /// <summary>
        /// Displays Details View
        /// </summary>
        /// <param name="id">The Id of BlogPost</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
          
            var blog = await blogPostService.GetByIdAsync<BlogPostViewModel>(id);

            if (blog == null)
            {
                return new StatusCodeResult(404);
            }

            var tags = await tagBlogPostService.GetTagByPostId(id);
            if (tags == null)
            {
                return new StatusCodeResult(404);
            }
            
            var model = new BlogDetailViewModel()
            {
                blog = blog,
                tags = tags
            };

            return View(model);
        }
    }
}
