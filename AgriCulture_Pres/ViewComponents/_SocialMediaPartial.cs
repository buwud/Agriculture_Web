using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.ViewComponents
{
	public class _SocialMediaPartial:ViewComponent
	{
		private readonly ISocialMediaService _mediaService;

		public _SocialMediaPartial(ISocialMediaService mediaService)
		{
			_mediaService = mediaService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _mediaService.GetListAll();
			return View(values);
		}
	}
}
