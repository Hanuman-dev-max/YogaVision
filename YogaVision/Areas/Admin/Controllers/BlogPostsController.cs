

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPosts;

    public class BlogPostsController : AdministrationController
    {
        private readonly IBlogPostsService blogPostsService;
        private readonly ITagService tagService;
        private readonly ITagBlogPostsService tagBlogPostsService;


        private readonly ICloudinaryService cloudinaryService;

        public BlogPostsController(
        IBlogPostsService blogPostsService,
        ICloudinaryService cloudinaryService,
          ITagService tagService,
          ITagBlogPostsService tagBlogPostsService)
        {
            this.blogPostsService = blogPostsService;
            this.cloudinaryService = cloudinaryService;
            this.tagService = tagService;
            this.tagBlogPostsService = tagBlogPostsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new BlogPostsListViewModel
            {
                BlogPosts = await this.blogPostsService.GetAllAsync<BlogPostViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddBlogPost()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlogPost(BlogPostInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Title);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                imageUrl = GlobalConstants.Images.CloudinaryMissing;
            }



            var blodId = await this.blogPostsService.AddAsync(input.Title,input.ShortContent, input.Content, input.Author, imageUrl);
            var tagIds = await this.tagService.AddRangeAsync(input.Tags);
            await this.tagBlogPostsService.AddAsync(blodId, tagIds);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {


            await this.blogPostsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}

