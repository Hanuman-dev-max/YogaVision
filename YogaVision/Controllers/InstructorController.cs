


namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Instructor;
    public class InstructorController : BaseController
    {
        private readonly IInstructorService instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            this.instructorService = instructorService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new InstructorsListViewModel()
            {
                Instructors = await instructorService.GetAllAsync<InstructorViewModel>()
            };
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var instructor = await instructorService.GetByIdAsync<InstructorViewModel>(id);
            return View(instructor);

        
        }
    }
}
