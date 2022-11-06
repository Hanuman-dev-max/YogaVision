

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Cities;
    using YogaVision.Core.Models.Studios;
    using YogaVision.Core.Services.Cloadinary;
    public class StudiosController : AdministrationController
    {
        private readonly IStudiosService studiosService;
      
        private readonly ICitiesService citiesService;
     
       
        private readonly ICloudinaryService cloudinaryService;

        public StudiosController(
            IStudiosService studiosService,
           
            ICitiesService citiesService,
          
            ICloudinaryService cloudinaryService)
        {
            this.studiosService = studiosService;
           
            this.citiesService = citiesService;
            
            
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new StudiosListViewModel
            {
                Studios = await this.studiosService.GetAllAsync<StudioViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddStudio()
        {
            
            var cities = await this.citiesService.GetAllAsync<CitySelectListViewModel>();

           
            this.ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudio(StudioInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Name);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                imageUrl = GlobalConstants.Images.CloudinaryMissing;
            }

            // Add Studio
            var studioId = await this.studiosService.AddAsync(input.Name, input.CityId, input.Address, imageUrl);

            

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudio(string id)
        {
         

            await this.studiosService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
