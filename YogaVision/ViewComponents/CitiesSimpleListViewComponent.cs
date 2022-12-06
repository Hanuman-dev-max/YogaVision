using Microsoft.AspNetCore.Mvc;
using YogaVision.Core.Contracts;
using YogaVision.Core.Models.City;

namespace YogaVision.ViewComponents
{
    /// <summary>
    /// Display all cities
    /// </summary>
    public class CitiesSimpleListViewComponent :ViewComponent
    {
        private readonly ICityService citiesService;

        /// <summary>
        /// Constructor for CitiesSimpleListViewComponent
        /// </summary>
        /// <param name="citiesService"></param>
        public CitiesSimpleListViewComponent(ICityService citiesService)
        {
            this.citiesService = citiesService;
        }
        /// <summary>
        /// Method for invoking the ViewComponent in RazorViewPage
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CitiesListViewModel
            {
                Cities = await this.citiesService.GetAllAsync<CityViewModel>()
            };

            return this.View(viewModel);
        }

    }
}
