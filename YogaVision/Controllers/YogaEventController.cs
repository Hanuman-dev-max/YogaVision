namespace YogaVision.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;

    using YogaVision.Core.Models.YogaEvent;
    using YogaVision.Extensions;

    public class YogaEventController : BaseController
    {
        private readonly IYogaEventService yogaEventService;
        private readonly IYogaEventApplicationUserService yogaEventApplicationUserService;
        private readonly IDateTimeParserService dateTimeParserService;
        public YogaEventController(IYogaEventService yogaEventService,
            IYogaEventApplicationUserService yogaEventApplicationUserService,
            IDateTimeParserService dateTimeParserService)

        {
            this.yogaEventService = yogaEventService;
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
                    YogaEvents = await this.yogaEventService
                    .GetByCityIdAsync<YogaEventViewModel>(sortId.Value, DateTime.Now)
                };
                return View(model);
            }
            else
            {
                var model = new YogaEventsListViewModel()
                {
                    YogaEvents = await this.yogaEventService.GetAllByDateAsync<YogaEventViewModel>(DateTime.Now)
                };
                return View(model);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Reserve(string yogaEventId, int? sortId)
        {
            var userid = User.Id();

            await yogaEventApplicationUserService.AddAsync(yogaEventId, userid);

            await yogaEventService.SubstarctSeat(yogaEventId);

            return RedirectToAction("Index", new { sortId = sortId });
        }
        [HttpPost]
        public async Task<IActionResult> Unreserve(string yogaEventId, int? sortId)
        {
            var userid = User.Id();

            await yogaEventApplicationUserService.DeleteAsync(yogaEventId, userid);

            await yogaEventService.AddSeat(yogaEventId);

            return RedirectToAction("Index", new { sortId = sortId });
        }



    }
}
