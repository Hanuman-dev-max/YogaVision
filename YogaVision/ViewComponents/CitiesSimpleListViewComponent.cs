using Microsoft.AspNetCore.Mvc;
using YogaVision.Core.Contracts;
using YogaVision.Core.Models.Cities;

namespace YogaVision.ViewComponents
{
    public class CitiesSimpleListViewComponent :ViewComponent
    {
        private readonly ICitiesService citiesService;

        public CitiesSimpleListViewComponent(ICitiesService citiesService)
        {
            this.citiesService = citiesService;
        }

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
