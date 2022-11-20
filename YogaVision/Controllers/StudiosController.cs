
namespace YogaVision.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using YogaVision.Core.Contracts;
    using YogaVision.Core.Models.Studios;

    public class StudiosController : BaseController
    {
        private readonly IStudiosService studiosService;
        public StudiosController(IStudiosService studiosService)
        {
            this.studiosService = studiosService;
        }

        public async Task<IActionResult> Index()
        {

            var model = new StudiosListViewModel()
            {
                Studios = await studiosService.GetAllAsync<StudioViewModel>()
            };
            return View(model);
        }
    }
}
