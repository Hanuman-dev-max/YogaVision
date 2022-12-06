namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Instructor;
    /// <summary>
    /// Controller for Instructor model
    /// </summary>
    public class InstructorController : BaseController
    {
        private readonly IInstructorService instructorService;
        /// <summary>
        /// Constructor of InstructorController
        /// </summary>
        /// <param name="instructorService">Interface of type IInstructorService</param>
        public InstructorController(IInstructorService instructorService)
        {
            this.instructorService = instructorService;
        }
        /// <summary>
        /// Displays Index View
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var model = new InstructorsListViewModel()
            {
                Instructors = await instructorService.GetAllAsync<InstructorViewModel>()
            };
            return View(model);
        }
        /// <summary>
        /// Displays Details View
        /// </summary>
        /// <param name="id">The Id of the Instructor</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var instructor = await instructorService.GetByIdAsync<InstructorViewModel>(id);
            return View(instructor);
        }
    }
}
