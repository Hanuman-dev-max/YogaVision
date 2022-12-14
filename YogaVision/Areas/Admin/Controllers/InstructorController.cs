namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    using YogaVision.Core.Models.City;
    using YogaVision.Core.Models.Instructor;
    using YogaVision.Core.Models.Studio;

    using YogaVision.Core.Services;

    /// <summary>
    /// Controller for Instructor Model in Admin Area
    /// </summary>
    public class InstructorController : AdministrationController
    {
        private readonly IInstructorService instructorService;
        private readonly ICloudinaryService cloudinaryService;

        /// <summary>
        /// Constructor of InstructorController
        /// </summary>
        /// <param name="instructorService">Object of type IInstructorService</param>
        /// <param name="cloudinaryService">Onkect of type ICloudinaryService</param>
        public InstructorController(
            IInstructorService instructorService,
            ICloudinaryService cloudinaryService)
        {
            this.instructorService = instructorService;
            this.cloudinaryService = cloudinaryService;
        }
        /// <summary>
        /// Displays Index View
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var viewModel = new InstructorsListViewModel
            {
                Instructors = await this.instructorService.GetAllAsync<InstructorViewModel>(),
            };
            return this.View(viewModel);
        }
        /// <summary>
        /// Displays AddInstructor View
        /// </summary>
        /// <returns></returns>
        public IActionResult AddInstructor()
        {
            return this.View();
        }
        /// <summary>
        /// HttpPost Method which handle adding of Instructor
        /// </summary>
        /// <param name="input">Interface of type InstructorInputModel</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddInstructor(InstructorInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Nickname);
            }
            catch (System.Exception)
            {
                //In case of missing Cloudinary configuration from appsettings.json
               imageUrl = GlobalConstants.Images.CloudinaryMissing;
            }
            string imageUrlFirst;
            try
            {
                imageUrlFirst = await this.cloudinaryService.UploadPictureAsync(input.ImageFirst, input.Nickname+"1");
            }
            catch (System.Exception)
            {
                //In case of missing Cloudinary configuration from appsettings.json
                imageUrlFirst = GlobalConstants.Images.CloudinaryMissing;
            }
            string imageUrlSecond;
            try
            {
                imageUrlSecond = await this.cloudinaryService.UploadPictureAsync(input.ImageSecond, input.Nickname+"2");
            }
            catch (System.Exception)
            {
                //In case of missing Cloudinary configuration from appsettings.json
                imageUrlSecond = GlobalConstants.Images.CloudinaryMissing;
            }
            string imageUrlThird;
            try
            {
                imageUrlThird = await this.cloudinaryService.UploadPictureAsync(input.ImageThird, input.Nickname+"3");
            }
            catch (System.Exception)
            {
                //In case of missing Cloudinary configuration from appsettings.json
                imageUrlThird = GlobalConstants.Images.CloudinaryMissing;
            }
            var createdOn = DateTime.Now;
            //Task AddAsync(string firstName, string lastName, string description, string nickName, string imageUrl);
            await this.instructorService.AddAsync(input.FirstName,input.LastName, input.Description, input.Nickname, imageUrl,
                imageUrlFirst, imageUrlSecond, imageUrlThird, input.FacebookLink);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// HttpPost Method which handle deleting of Instructor
        /// </summary>
        /// <param name="id">The Id of Instructor</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteInstructor(int id)
        { 
            await this.instructorService.DeleteAsync(id);
            return this.RedirectToAction("Index");
        }
        public async Task<IActionResult> EditInstructor(int id)
        {
            var instructor = await instructorService.GetByIdAsync<InstructorViewModel>(id);
            var model = new InstructorEditModel()
            {
                Id = id,
                Nickname = instructor.NickName,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Description = instructor.Description,
                FacebookLink = instructor.FacebookLink,
                OldImage = instructor.ImageUrl,
                OldImageFirst = instructor.ImageUrlFirst,
                OldImageSecond = instructor.ImageUrlSecond,
                OldImageThird = instructor.ImageUrlThird
            };
            return this.View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditInstructor(InstructorEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Nickname);
            }
            catch (System.Exception)
            {
                
                imageUrl = input.OldImage;
            }
            string imageUrlFirst;
            try
            {
                imageUrlFirst = await this.cloudinaryService.UploadPictureAsync(input.ImageFirst, input.Nickname + "1");
            }
            catch (System.Exception)
            {
                
                imageUrlFirst = input.OldImageFirst;
            }
            string imageUrlSecond;
            try
            {
                imageUrlSecond = await this.cloudinaryService.UploadPictureAsync(input.ImageSecond, input.Nickname + "2");
            }
            catch (System.Exception)
            {
                
                imageUrlSecond = input.OldImageSecond;
            }
            string imageUrlThird;
            try
            {
                imageUrlThird = await this.cloudinaryService.UploadPictureAsync(input.ImageThird, input.Nickname + "3");
            }
            catch (System.Exception)
            {
               
                imageUrlThird = input.OldImageThird;
            }
            var createdOn = DateTime.Now;
            //Task AddAsync(string firstName, string lastName, string description, string nickName, string imageUrl);
            await this.instructorService.EditAsync(input.Id,input.FirstName, input.LastName, input.Description, input.Nickname, imageUrl,
                imageUrlFirst, imageUrlSecond, imageUrlThird, input.FacebookLink);
            return this.RedirectToAction("Index");
        }



    }
}
