

namespace YogaVision.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
   
    using YogaVision.Core.Models.YogaEvents;
  
    using YogaVision.Infrastructure.Data.Models;
    public class YogaEventsController : BaseController
    {
        private readonly IYogaEventsService yogaEventsService;
        //private readonly ICitiesService citiesService;


        private readonly IDateTimeParserService dateTimeParserService;
        public YogaEventsController(IYogaEventsService yogaEventsService, IDateTimeParserService dateTimeParserService)
        //(IYogaEventsService yogaEventsService,
        //    ICitiesService citiesService,
        //    IDateTimeParserService dateTimeParserService)
        {
            this.yogaEventsService = yogaEventsService;
            //this.citiesService = citiesService;
            this.dateTimeParserService = dateTimeParserService;
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new YogaEventsListViewModel
            {
                YogaEvents = await this.yogaEventsService.GetAllAsync<YogaEventViewModel>()
            };
            return this.View(viewModel);
        }
        //int? sortId   // CityId
         
        //{
        //    if (sortId != null)
        //    {
        //        var yogaEvents = await this.yogaEventsService
        //            .GetByCityIdAsync<YogaEventViewModel>(sortId.Value);
        //        if (yogaEvents == null)
        //        {
        //            return new StatusCodeResult(404);
        //        }

        //        var city = await citiesService.GetByIdAsync<City>(sortId.Value);
        //        this.ViewData["CityName"] = city.Name;
        //    }
        //    else
        //    {
        //        var yogaEvents =
        //                await this.yogaEventsService.GetAllAsync<YogaEventViewModel>()
                
                
        //    }

           
      
    }
}
