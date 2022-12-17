using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
