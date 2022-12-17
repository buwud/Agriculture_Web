using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.ViewComponents
{
    public class _ServicePartial:ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _ServicePartial(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var items = _serviceService.GetListAll();
            return View(items);
        }
    }
}
