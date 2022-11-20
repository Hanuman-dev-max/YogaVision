

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
        public async Task<IActionResult> Index(int? sortId)
        {



            if (sortId != null)
            {
                var model = new YogaEventsListViewModel()
                {
                    YogaEvents = await this.yogaEventsService
                    .GetByCityIdAsync<YogaEventViewModel>(sortId.Value, DateTime.Now)
                };
                return View(model);
            }
            else
            {
                var model = new YogaEventsListViewModel()
                {
                    YogaEvents = await this.yogaEventsService.GetAllByDateAsync<YogaEventViewModel>(DateTime.Now)
                };
                return View(model);
            }





        }
    }
}
