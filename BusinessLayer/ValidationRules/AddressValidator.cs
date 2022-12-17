using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!");
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Description-1 is required!");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Description-2 is required!");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Description-3 is required!");
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Map info is required!");

            RuleFor(x => x.Description).MaximumLength(25).WithMessage("Shorten the description!");
            RuleFor(x => x.Description1).MaximumLength(25).WithMessage("Shorten the description!");
            RuleFor(x => x.Description2).MaximumLength(25).WithMessage("Shorten the description!");
            RuleFor(x => x.Description3).MaximumLength(25).WithMessage("Shorten the description!");

           // @"^(0(\d{3})-(\d{3})-(\d{2})-(\d{2}))$"
           RuleFor(x => x.Description3).MaximumLength(25).WithMessage("Shorten the description!");
        }
    }
}