using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement a)
        {
            a.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            a.Status = true;
            _announcementService.Insert(a);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.GetById(id);
            _announcementService.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {

            var value = _announcementService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement a)
        {
            _announcementService.Update(a);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            _announcementService.AnnouncementStatus(id);
            return RedirectToAction("Index");
        }
    }
}
