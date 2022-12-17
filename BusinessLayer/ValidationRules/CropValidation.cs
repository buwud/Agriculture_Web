using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CropValidation : AbstractValidator<Crop>
    {
        public CropValidation()
        {
            RuleFor(x=>x.cropname).NotEmpty().WithMessage("Name is required!");
            RuleFor(x=>x.cropnum).NotEmpty().WithMessage("Amount is required!");

            RuleFor(x => x.cropname).MinimumLength(3).WithMessage("Enter the name more than 3 characters");
            RuleFor(x => x.cropname).MaximumLength(40).WithMessage("Enter the name more than 40 characters");
            RuleFor(x => x.cropname).Matches(@"^[a-zA-Z]+$");

        }
    }
}
