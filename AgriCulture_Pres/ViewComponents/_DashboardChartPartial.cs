using BusinessLayer.Abstract;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.ViewComponents
{
    public class _DashboardChartPartial:ViewComponent
    {
        AgriCultureContext c = new AgriCultureContext();
        private readonly ICropService _cropService;
        public _DashboardChartPartial(ICropService cropService)
        {
            _cropService = cropService;
        }

        public IViewComponentResult Invoke()
        {
                ViewBag.vName0 = c.Crops.Where(x => x.cropid == 1).Select(x => x.cropname).FirstOrDefault();
                ViewBag.vName1 = c.Crops.Where(x => x.cropid == 2).Select(x => x.cropname).FirstOrDefault();
                ViewBag.vName2 = c.Crops.Where(x => x.cropid == 3).Select(x => x.cropname).FirstOrDefault();
                ViewBag.vName3 = c.Crops.Where(x => x.cropid == 4).Select(x => x.cropname).FirstOrDefault();
                ViewBag.vName4 = c.Crops.Where(x => x.cropid == 5).Select(x => x.cropname).FirstOrDefault();
                ViewBag.vName5 = c.Crops.Where(x => x.cropid == 6).Select(x => x.cropname).FirstOrDefault();
                ViewBag.vName6 = c.Crops.Where(x => x.cropid == 7).Select(x => x.cropname).FirstOrDefault();
                ViewBag.vName7 = c.Crops.Where(x => x.cropid == 8).Select(x => x.cropname).FirstOrDefault();

                ViewBag.vAmount0 = c.Crops.Where(x => x.cropid == 1).Select(x => x.cropnum).FirstOrDefault();
                ViewBag.vAmount1 = c.Crops.Where(x => x.cropid == 2).Select(x => x.cropnum).FirstOrDefault();
                ViewBag.vAmount2 = c.Crops.Where(x => x.cropid == 3).Select(x => x.cropnum).FirstOrDefault();
                ViewBag.vAmount3 = c.Crops.Where(x => x.cropid == 4).Select(x => x.cropnum).FirstOrDefault();
                ViewBag.vAmount4 = c.Crops.Where(x => x.cropid == 5).Select(x => x.cropnum).FirstOrDefault();
                ViewBag.vAmount5 = c.Crops.Where(x => x.cropid == 6).Select(x => x.cropnum).FirstOrDefault();
                ViewBag.vAmount6 = c.Crops.Where(x => x.cropid == 7).Select(x => x.cropnum).FirstOrDefault();
                ViewBag.vAmount7 = c.Crops.Where(x => x.cropid == 8).Select(x => x.cropnum).FirstOrDefault();

            return View();
        }
    }
}