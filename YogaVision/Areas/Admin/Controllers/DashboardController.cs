namespace YogaVision.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    /// <summary>
    /// Controller resonsible for Dashboard 
    /// </summary>
    public class DashboardController : AdministrationController
    {
        /// <summary>
        /// Dispays the Index View
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
