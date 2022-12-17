using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        public IActionResult Index()
        {
            var values=_addressService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var value=_addressService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditAddress(Address a)
        {
            AddressValidator validationRules = new AddressValidator();
            ValidationResult result = validationRules.Validate(a);
            if (result.IsValid)
            {
                _addressService.Update(a);
                return RedirectToAction("Index");
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
    }
}