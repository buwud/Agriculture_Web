using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AgriCulture_Pres.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
            var values=_imageService.GetListAll();
            if(values == null)
            {
                return NotFound();
            }
            else
            return View(values);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image i)
        {
            ImageValidator validationRules = new ImageValidator();
            ValidationResult result = validationRules.Validate(i);
            if (result.IsValid)
            {
                _imageService.Insert(i);
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
        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var value=_imageService.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditImage(Image m)
        {
            ImageValidator validationRules=new ImageValidator();
            ValidationResult result = validationRules.Validate(m);
            if (result.IsValid)
            {
                _imageService.Update(m);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteImage(int id)
        {
            var value = _imageService.GetById(id);
            _imageService.Delete(value);
            return RedirectToAction("Index");
        }
    }
}
