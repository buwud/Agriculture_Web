using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace AgriCulture_Pres.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ITeamService _teamService;
        private readonly IAboutService _aboutService;
        private readonly IAnnouncementService _announcementService;

		public DefaultController(IAboutService aboutService, IContactService contactService, ITeamService teamService, IAnnouncementService announcementService)
		{
            _announcementService = announcementService;
            _aboutService = aboutService;
            _contactService = contactService;
            _teamService = teamService;
		}

        public IActionResult Index()
        {
            ViewBag.aboutUs = _aboutService.GetListAll().Select(x => x.AboutUs).FirstOrDefault();
            ViewBag.aboutHistory = _aboutService.GetListAll().Select(x => x.AboutHistory).FirstOrDefault();
            ViewBag.teams = _teamService.GetListAll();
            ViewBag.newsTitle = _announcementService.GetListAll().Select(x => x.Title).FirstOrDefault();
            ViewBag.Desc = _announcementService.GetListAll().Select(x => x.Description).FirstOrDefault();
            ViewBag.newsDate = _announcementService.GetListAll().Select(x => x.Date).FirstOrDefault();

            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SendMessage(Contact c)
        {
            MessageValidator validationRules = new MessageValidator();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {
                c.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                _contactService.Insert(c);
                return RedirectToAction("Index", "Default");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public PartialViewResult ScriptPartial()
        { 
            return PartialView();
        }
    }
}