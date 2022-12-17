using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriCulture_Pres.Controllers
{
    public class CropController : Controller
    {
        private readonly ICropService _cropService;

        public CropController(ICropService cropService)
        {
            _cropService = cropService;
        }

        public IActionResult Index()
        {
            var values = _cropService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCrop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCrop(Crop c)
        {
            CropValidation validationRules = new CropValidation();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {
                _cropService.Insert(c);
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
        public IActionResult DeleteCrop(int id)
        {
            var value=_cropService.GetById(id);
            _cropService.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditCrop(int id)
        {
            var value = _cropService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditCrop(Crop c)
        {
            CropValidation validationRules = new CropValidation();
            ValidationResult result = validationRules.Validate(c);
            if (result.IsValid)
            {
                _cropService.Update(c);
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