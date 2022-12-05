


namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using YogaVision.Core.Models.Instructor;
    using YogaVision.Core.Models.Studio;
    using YogaVision.Core.Models.YogaEvent;
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;

    public class YogaEventController : AdministrationController
    {
        private readonly IStudioService studioService;
        private readonly IInstructorService instructorService;
        private readonly IYogaEventService yogaEventService;
        private readonly IDateTimeParserService dateTimeParserService;


        public YogaEventController(IStudioService studioService, 
            IInstructorService instructorService,
            IYogaEventService yogaEventService,
            IDateTimeParserService dateTimeParserService)
        {
            this.studioService = studioService;
            this.instructorService = instructorService;
            this.yogaEventService = yogaEventService;
            this.dateTimeParserService = dateTimeParserService;
        }


        public async Task<IActionResult> Index()
        {
            var viewModel = new YogaEventsListViewModel
            {
                YogaEvents = await this.yogaEventService.GetAllAsync<YogaEventViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddYogaEvent()
        {
            
            
            var instructors = await this.instructorService.GetAllAsync<InstructorSelectListViewModel>();

            var studios = await this.studioService.GetAllAsync<StudioSelectListViewModel>();


            this.ViewData["Instructors"] = new SelectList(instructors, "Id", "Nickname");
            this.ViewData["Studios"] = new SelectList(studios, "Id", "Name");


            var model = new YogaEventInputModel();
            
            return this.View(model);


           
        }

        [HttpPost]
        public async Task<IActionResult> AddYogaEvent(YogaEventInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            DateTime dateTime;
            try
            {
                dateTime = this.dateTimeParserService.ConvertStrings(input.Date, input.Time);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("AddYogaEvent");
            }
            await this.yogaEventService.AddAsync(input.StudioId, input.InstructorId, dateTime, input.Description, input.Duration, input.Seats);
            return this.RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteYogaEvent(string id)
        {


            await this.yogaEventService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
