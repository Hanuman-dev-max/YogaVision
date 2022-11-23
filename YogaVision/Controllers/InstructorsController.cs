


namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Instructors;
    public class InstructorsController : BaseController
    {
        private readonly IInstructorsService instructorsService;
        public InstructorsController(IInstructorsService instructorsService)
        {
            this.instructorsService = instructorsService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new InstructorsListViewModel()
            {
                Instructors = await instructorsService.GetAllAsync<InstructorViewModel>()
            };
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var instructor = await instructorsService.GetByIdAsync<InstructorViewModel>(id);
            return View(instructor);

        
        }
    }
}
