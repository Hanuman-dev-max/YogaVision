

//namespace YogaVision.Areas.Admin.Controllers
//{
//    using Microsoft.AspNetCore.Mvc;
//    using YogaVision.Common;
//    using YogaVision.Core.Contracts;
//    using YogaVision.Core.Models.BlogPosts;
//    using YogaVision.Core.Models.Instructors;
//    using YogaVision.Core.Services.Cloadinary;
//    public class InstructorsController : AdministrationController
//    {
//        private readonly IInstructorsService instructorsService;
//        private readonly ICloudinaryService cloudinaryService;

//        public InstructorsController(
//            IInstructorsService instructorsService,
//            ICloudinaryService cloudinaryService)
//        {
//            this.instructorsService = instructorsService;
//            this.cloudinaryService = cloudinaryService;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var viewModel = new InstructorsListViewModel
//            {
//                Instructors = await this.instructorsService.GetAllAsync<InstructorViewModel>(),
//            };
//            return this.View(viewModel);
//        }

//        public IActionResult AddBlogPost()
//        {
//            return this.View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddBlogPost(InstructorInputModel input)
//        {
//            if (!this.ModelState.IsValid)
//            {
//                return this.View(input);
//            }

//            string imageUrl;
//            try
//            {
//                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Title);
//            }
//            catch (System.Exception)
//            {
//                In case of missing Cloudinary configuration from appsettings.json
//               imageUrl = GlobalConstants.Images.CloudinaryMissing;
//            }
//            var createdOn = DateTime.Now;
//            await this.blogPostsService.AddAsync(input.Title, input.Content, input.Author, imageUrl, createdOn);
//            return this.RedirectToAction("Index");
//        }

//        [HttpPost]
//        public async Task<IActionResult> DeleteBlogPost(int id)
//        {


//            await this.blogPostsService.DeleteAsync(id);

//            return this.RedirectToAction("Index");
//        }
//    }
//}
