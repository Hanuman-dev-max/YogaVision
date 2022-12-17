

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    using YogaVision.Core.Models.FoodRecipe;

    using YogaVision.Core.Services;

    /// <summary>
    /// Controller which will handles BlogPosts in AdminArea 
    /// </summary>
    public class BlogPostController : AdministrationController
    {
        private readonly IBlogPostService blogPostService;
        private readonly ITagService tagService;
        private readonly ITagBlogPostService tagBlogPostService;
        private readonly ICloudinaryService cloudinaryService;
        /// <summary>
        /// Constructor of BlogPostController
        /// </summary>
        /// <param name="blogPostService">Interface of type IBlogPostService</param>
        /// <param name="cloudinaryService">Interface of type ICloudinaryService</param>
        /// <param name="tagService">Interface of type ITagService</param>
        /// <param name="tagBlogPostService">Interface of type ITagBlogPostService</param>
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
        /// <summary>
        /// Displays a View with all blog posts
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var viewModel = new BlogPostsListViewModel
            {
                BlogPosts = await this.blogPostService.GetAllAsync<BlogPostViewModel>(),
            };
            return this.View(viewModel);
        }
        /// <summary>
        /// Displays a View for addong a BlogPost
        /// </summary>
        /// <returns></returns>
        public IActionResult AddBlogPost()
        {
            var model = new BlogPostInputModel();
            return this.View(model);
        }
        /// <summary>
        /// HttpPost Method which handles adding a BlogPost
        /// </summary>
        /// <param name="input">BlogPostInputModel</param>
        /// <returns></returns>
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
        /// <summary>
        /// HttpPost Method which handles deleting a BlogPost
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            await this.blogPostService.DeleteAsync(id);
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EditBlogPost(int id)
        {
            var blogPost = await blogPostService.GetByIdAsync<BlogPostViewModel>(id);
            var model = new BlogPostEditModel()
            {
                Id = id,
                Title = blogPost.Title,
                Author = blogPost.Author,
                ShortContent = blogPost.ShortContent,
                Content = blogPost.Content,
                OldImage = blogPost.ImageUrl,
                Tags = await tagService.GetAllByPostId(id)
            };
            return this.View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditBlogPost(BlogPostEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            string imageUrl;
            if (input.Image == null)
            {
                imageUrl = input.OldImage;
            }
            else
            {
                try
                {
                    imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Title);
                }
                catch (System.Exception)
                {

                    imageUrl = input.OldImage;
                }
            }
            // Edit BlogPost
            await tagBlogPostService.ClearBlogTags(input.Id);
            
            var tagIds = await this.tagService.AddRangeAsync(input.Tags);
            await this.blogPostService.EditAsync(input.Id, input.Title, input.ShortContent, input.Content, input.Author, imageUrl, tagIds);
            return this.RedirectToAction("Index");
        }
    }
}

