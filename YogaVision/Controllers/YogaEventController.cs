namespace YogaVision.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;

    using YogaVision.Core.Models.YogaEvent;
    using YogaVision.Extensions;
    /// <summary>
    /// Controller which handles the Schedule
    /// </summary>
    public class YogaEventController : BaseController
    {
        private readonly IYogaEventService yogaEventService;
        private readonly IYogaEventApplicationUserService yogaEventApplicationUserService;
        private readonly IDateTimeParserService dateTimeParserService;
        /// <summary>
        /// Contructor for YogaEventController
        /// </summary>
        /// <param name="yogaEventService">Interface for IYogaEventService </param>
        /// <param name="yogaEventApplicationUserService">Interface for IYogaEventApplicationUserService</param>
        /// <param name="dateTimeParserService">Interface for IDateTimeParserService</param>
        public YogaEventController(IYogaEventService yogaEventService,
            IYogaEventApplicationUserService yogaEventApplicationUserService,
            IDateTimeParserService dateTimeParserService)

        {
            this.yogaEventService = yogaEventService;
            this.yogaEventApplicationUserService = yogaEventApplicationUserService;
            this.dateTimeParserService = dateTimeParserService;
        }
        /// <summary>
        /// Displays Index View
        /// </summary>
        /// <param name="sortId">The Id of the City(optional)</param>
        /// <returns></returns>
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
        /// <summary>
        /// Reserve a seat of YogaEvent for the ApplicationUser
        /// </summary>
        /// <param name="yogaEventId">Id of the YogaEvent</param>
        /// <param name="sortId">Id of the City</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Reserve(string yogaEventId, int? sortId)
        {
            var userid = User.Id();

            await yogaEventApplicationUserService.AddAsync(yogaEventId, userid);

            await yogaEventService.SubstarctSeat(yogaEventId);

            return RedirectToAction("Index", new { sortId = sortId });
        }
        /// <summary>
        /// Unreserve a seat of YogaEvent 
        /// </summary>
        /// <param name="yogaEventId">Id of the YogaEvent</param>
        /// <param name="sortId">Id of the City</param>
        /// <returns></returns>
        
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
