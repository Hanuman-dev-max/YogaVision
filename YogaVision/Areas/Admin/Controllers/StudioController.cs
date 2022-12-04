

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.City;
    using YogaVision.Core.Models.Studio;
    public class StudioController : AdministrationController
    {
        private readonly IStudioService studioService;
      
        private readonly ICityService cityService;
     
       
        private readonly ICloudinaryService cloudinaryService;

        public StudioController(
            IStudioService studioService,
           
            ICityService cityService,
          
            ICloudinaryService cloudinaryService)
        {
            this.studioService = studioService;
           
            this.cityService = cityService;
            
            
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new StudiosListViewModel
            {
                Studios = await this.studioService.GetAllAsync<StudioViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddStudio()
        {
            
            var cities = await this.cityService.GetAllAsync<CitySelectListViewModel>();

           
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
            var studioId = await this.studioService.AddAsync(input.Name, input.CityId, input.Address, imageUrl);

            

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudio(int id)
        {
         

            await this.studioService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
