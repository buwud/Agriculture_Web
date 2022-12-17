using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Url is required!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!");

            RuleFor(x => x.Title).MinimumLength(2).WithMessage("Enter the title more than 3 characters");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Enter the title less than 20 characters!");

            RuleFor(x => x.Description).MaximumLength(45).WithMessage("Enter the description less than 45 characters!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Enter the description more than 10 characters!");


        }
    }
}
