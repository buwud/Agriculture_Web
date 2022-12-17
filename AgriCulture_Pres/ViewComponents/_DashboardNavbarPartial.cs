using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.ViewComponents
{
    public class _DashboardNavbarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
