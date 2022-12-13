

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.City;
    using YogaVision.Core.Models.Studio;
    /// <summary>
    /// Contoller responsible for Studio model in AdminArea
    /// </summary>
    public class StudioController : AdministrationController
    {
        private readonly IStudioService studioService;
        private readonly ICityService cityService;
        private readonly ICloudinaryService cloudinaryService;

        /// <summary>
        /// Constructor of StudioController
        /// </summary>
        /// <param name="studioService">Interface of type IStudioService</param>
        /// <param name="cityService">Interface of type ICityService</param>
        /// <param name="cloudinaryService">Interface of type ICloudinaryService</param>
        public StudioController(
            IStudioService studioService,
           
            ICityService cityService,
          
            ICloudinaryService cloudinaryService)
        {
            this.studioService = studioService;
           
            this.cityService = cityService;
            
            
            this.cloudinaryService = cloudinaryService;
        }
        /// <summary>
        /// Displays Index View
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var viewModel = new StudiosListViewModel
            {
                Studios = await this.studioService.GetAllAsync<StudioViewModel>(),
            };
            return this.View(viewModel);
        }
        /// <summary>
        /// Displays AddStudio View
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AddStudio()
        {
            
            var cities = await this.cityService.GetAllAsync<CitySelectListViewModel>();

           
            this.ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            return this.View();
        }
        /// <summary>
        /// HttpPost Method which handles adding of a Studio
        /// </summary>
        /// <param name="input">Object of type StudioInputModel</param>
        /// <returns></returns>
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
        /// <summary>
        /// HttpPost Method which handles deleting of a Studio
        /// </summary>
        /// <param name="id">The Id of a Studio</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteStudio(int id)
        {
            await this.studioService.DeleteAsync(id);
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> EditStudio(int id)
        {

            var cities = await this.cityService.GetAllAsync<CitySelectListViewModel>();
            this.ViewData["Cities"] = new SelectList(cities, "Id", "Name");
            var studio = await studioService.GetByIdAsync<StudioViewModel>(id);
            var model = new StudioEditModel()
            {
                Id = id,
                Address = studio.Address,
                Name = studio.Name,
                CityId = await cityService.GetIdByNameAsync(studio.CityName),
                OldImage = studio.ImageUrl,
             
                 
            };
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudio(StudioEditModel input)
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

                imageUrl = input.OldImage;
            }

            // Edit Studio
            await this.studioService.EditAsync(input.Id, input.Name, input.CityId, input.Address, imageUrl);



            return this.RedirectToAction("Index");
        }
    }
}
