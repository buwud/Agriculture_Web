using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;

namespace AgriCulture_Pres.ViewComponents
{
    public class _DashboardOverviewPartial:ViewComponent
    {
        AgriCultureContext c = new AgriCultureContext();
        private readonly IContactService _contactService;

        public _DashboardOverviewPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            int i = 0;
            ViewBag.teams = c.Teams.Count();
            ViewBag.services = c.Services.Count();
            ViewBag.messages = c.Contacts.Count();
            //message number received this month
            ViewBag.monthMessages = c.Contacts.Where(x => (x.Date.Month == DateTime.Now.Month)&&(x.Date.Year == DateTime.Now.Year)).Count();

            ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();

            ViewBag.grower = c.Teams.Where(x => x.Title == "Grower").Select(x => x.Name).FirstOrDefault();
            ViewBag.grainElevatorOperator = c.Teams.Where(x => x.Title == "Grain Elevator Operator").Select(x => x.Name).FirstOrDefault();
            ViewBag.salesRepresentative = c.Teams.Where(x => x.Title == "Sales Representative").Select(x => x.Name).FirstOrDefault();
            ViewBag.purchasingAgent = c.Teams.Where(x => x.Title == "Purchasing Agent").Select(x => x.Name).FirstOrDefault();
            ViewBag.warehouseManager = c.Teams.Where(x => x.Title == "Warehouse Manager").Select(x => x.Name).FirstOrDefault();

            return View();
        }
    }
}