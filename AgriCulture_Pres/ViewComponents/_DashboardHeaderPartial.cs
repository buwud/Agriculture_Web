using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.ViewComponents
{
    public class _DashboardHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }

    }
}
