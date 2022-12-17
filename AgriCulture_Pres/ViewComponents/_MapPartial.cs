using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.ViewComponents
{
	public class _MapPartial:ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			AgriCultureContext agriCultureContext = new AgriCultureContext();
			var value = agriCultureContext.Addresses.Select(x => x.MapInfo).FirstOrDefault();
			ViewBag.v = value;
			return View();
		}
	}
}
