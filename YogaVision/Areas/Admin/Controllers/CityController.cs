

namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using YogaVision.Common;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.City;
    using YogaVision.Core.Models.Studio;

    using YogaVision.Core.Services;

    /// <summary>
    /// Controller which will handles Cities in AdminArea 
    /// </summary>
    public class CityController : AdministrationController
    {
        private readonly ICityService cityService;
        /// <summary>
        /// The constructor of the controller
        /// </summary>
        /// <param name="cityService">Interface of type ICityService</param>
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        /// <summary>
        /// Displays a View with all Cities
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var viewModel = new CitiesListViewModel
            {
                Cities = await this.cityService.GetAllAsync<CityViewModel>(),
            };
            return this.View(viewModel);
        }
        /// <summary>
        /// Dispays View for adding a City
        /// </summary>
        /// <returns></returns>
        public IActionResult AddCity()
        {
            return this.View();
        }
        /// <summary>
        /// HttpPost Method which handle adding of a City
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCity(CityInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.cityService.AddAsync(input.Name);

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// HttpPost Method which handles deleting a City
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteCity(int id)
        {
            
            await this.cityService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
        /// <summary>
        /// Displays EditCityView 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditCity(int id)
        {
            var city = await cityService.GetByIdAsync<CityViewModel>(id);
            var model = new CityEditModel()
            {
                Id = id,
                Name = city.Name,
            };
            return this.View(model);
        }
        
        /// <summary>
        /// Edits City 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditCity(CityEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            // Edit City
            await this.cityService.EditAsync(input.Id, input.Name);
            return this.RedirectToAction("Index");
        }

    }
}
