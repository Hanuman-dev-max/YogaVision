

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;

    public class BlogPostController : AdministrationController
    {
        private readonly IBlogPostService blogPostService;
        private readonly ITagService tagService;
        private readonly ITagBlogPostService tagBlogPostService;
        private readonly ICloudinaryService cloudinaryService;

        public BlogPostController(
        IBlogPostService blogPostService,
        ICloudinaryService cloudinaryService,
          ITagService tagService,
          ITagBlogPostService tagBlogPostService)
        {
            this.blogPostService = blogPostService;
            this.cloudinaryService = cloudinaryService;
            this.tagService = tagService;
            this.tagBlogPostService = tagBlogPostService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new BlogPostsListViewModel
            {
                BlogPosts = await this.blogPostService.GetAllAsync<BlogPostViewModel>(),
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



            var blodId = await this.blogPostService.AddAsync(input.Title,input.ShortContent, input.Content, input.Author, imageUrl);
            var tagIds = await this.tagService.AddRangeAsync(input.Tags);
            await this.tagBlogPostService.AddAsync(blodId, tagIds);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            await this.blogPostService.DeleteAsync(id);
            return this.RedirectToAction("Index");
        }
    }
}

