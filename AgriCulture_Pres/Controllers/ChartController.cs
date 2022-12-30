using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgriCulture_Pres.Controllers
{
    public class ChartController : Controller
    {
        private readonly ICropService _cropService;

        public ChartController(ICropService cropService)
        {
            _cropService = cropService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductChart()
        {
            List<Crop> CropClass = _cropService.GetListAll();
                
            return Json(new { jsonlist = CropClass });
        }
    }
}
