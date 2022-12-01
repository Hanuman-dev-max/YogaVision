
namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Studio;

    public class StudioController : BaseController
    {
        private readonly IStudioService studioService;
        public StudioController(IStudioService studioService)
        {
            this.studioService = studioService;
        }

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
