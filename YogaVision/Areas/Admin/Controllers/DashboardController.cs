using Microsoft.AspNetCore.Mvc;

namespace YogaVision.Areas.Admin.Controllers
{
   
    public class DashboardController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
