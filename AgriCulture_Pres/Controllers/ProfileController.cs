using AgriCulture_Pres.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel m = new UserEditViewModel();
            m.name = values.Name;
            m.surname = values.Surname;
            m.email = values.Email;
            m.username = values.UserName;
            return View(m);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel m)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.UserName = m.username;
            values.Name = m.name;
            values.Surname = m.surname;
            values.PhoneNumber = m.phoneNumber;
            values.Email = m.email;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, m.password);
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}