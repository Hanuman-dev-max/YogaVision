﻿namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.BlogPost;
    using YogaVision.Core.Models.Instructor;
    public class InstructorController : AdministrationController
    {
        private readonly IInstructorService instructorService;
        private readonly ICloudinaryService cloudinaryService;

        public InstructorController(
            IInstructorService instructorService,
            ICloudinaryService cloudinaryService)
        {
            this.instructorService = instructorService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new InstructorsListViewModel
            {
                Instructors = await this.instructorService.GetAllAsync<InstructorViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddInstructor()
        {
            return this.View();
        }

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

        [HttpPost]
        public async Task<IActionResult> DeleteInstructor(int id)
        { 
            await this.instructorService.DeleteAsync(id);
            return this.RedirectToAction("Index");
        }
    }
}