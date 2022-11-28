namespace YogaVision.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;

    using YogaVision.Core.Models.YogaEvents;
    using YogaVision.Extensions;

    public class YogaEventsController : BaseController
    {
        private readonly IYogaEventsService yogaEventsService;
        //private readonly ICitiesService citiesService;
        private readonly IYogaEventApplicationUserService yogaEventApplicationUserService;

        private readonly IDateTimeParserService dateTimeParserService;
        public YogaEventsController(IYogaEventsService yogaEventsService,
            IYogaEventApplicationUserService yogaEventApplicationUserService,
            IDateTimeParserService dateTimeParserService)

        {
            this.yogaEventsService = yogaEventsService;
            this.yogaEventApplicationUserService = yogaEventApplicationUserService;
            this.dateTimeParserService = dateTimeParserService;
        }
        public async Task<IActionResult> Index(int? sortId)
        {
            ViewData["sortId"] = sortId;
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
        [HttpPost]
        public async Task<IActionResult> Reserve(string yogaEventId, int? sortId)
        {
            var userid = User.Id();

            await yogaEventApplicationUserService.AddAsync(yogaEventId, userid);

            await yogaEventsService.SubstarctSeat(yogaEventId);

            return RedirectToAction("Index", new { sortId = sortId });
        }
        [HttpPost]
        public async Task<IActionResult> Unreserve(string yogaEventId, int? sortId)
        {
            var userid = User.Id();

            await yogaEventApplicationUserService.DeleteAsync(yogaEventId, userid);

            await yogaEventsService.AddSeat(yogaEventId);

            return RedirectToAction("Index", new { sortId = sortId });
        }



    }
}
