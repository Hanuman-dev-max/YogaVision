
namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Studio;

    /// <summary>
    /// Controller for Studio model
    /// </summary>
    public class StudioController : BaseController
    {
        private readonly IStudioService studioService;
        /// <summary>
        /// Constructor for StudioController
        /// </summary>
        /// <param name="studioService">Interface for IStudioService</param>
        public StudioController(IStudioService studioService)
        {
            this.studioService = studioService;
        }
        /// <summary>
        /// Displays Index View
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {

            var model = new StudiosListViewModel()
            {
                Studios = await studioService.GetAllAsync<StudioViewModel>()
            };
            return View(model);
        }
    }
}
