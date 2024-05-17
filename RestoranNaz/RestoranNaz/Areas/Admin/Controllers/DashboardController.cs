using Microsoft.AspNetCore.Mvc;

namespace RestoranNaz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
