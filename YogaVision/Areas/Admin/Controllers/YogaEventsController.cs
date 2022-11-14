using Microsoft.AspNetCore.Mvc;
using YogaVision.Common;
using YogaVision.Core.Contracts;


namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using YogaVision.Core.Models.Cities;
    using YogaVision.Core.Models.Instructors;
    using YogaVision.Core.Models.Studios;
    using YogaVision.Core.Models.YogaEvents;
    using YogaVision.Infrastructure.Data.Models;

    public class YogaEventsController : AdministrationController
    {
        private readonly IStudiosService studiosService;
        private readonly IInstructorsService instructorsService;
        private readonly IYogaEventsService yogaEventsService;
        private readonly IDateTimeParserService dateTimeParserService;


        public YogaEventsController(IStudiosService studiosService, 
            IInstructorsService instructorsService,
            IYogaEventsService yogaEventsService,
            IDateTimeParserService dateTimeParserService)
        {
            this.studiosService = studiosService;
            this.instructorsService = instructorsService;
            this.yogaEventsService = yogaEventsService;
            this.dateTimeParserService = dateTimeParserService;
        }


        public async Task<IActionResult> Index()
        {
            var viewModel = new YogaEventsListViewModel
            {
                YogaEvents = await this.yogaEventsService.GetAllAsync<YogaEventViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddYogaEvent()
        {
            
            
            var instructors = await this.instructorsService.GetAllAsync<InstructorSelectListViewModel>();

            var studios = await this.studiosService.GetAllAsync<StudioSelectListViewModel>();


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
            await this.yogaEventsService.AddAsync(input.StudioId, input.InstructorId, dateTime, input.Description, input.Duration);
            return this.RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteYogaEvent(string id)
        {


            await this.yogaEventsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
