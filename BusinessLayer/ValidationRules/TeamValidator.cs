using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).Matches(@"^[a-zA-Z ]+$").WithMessage("Use only alphabetical characters");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Role is required");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image is required");

            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Enter the name less than 50 characters");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Enter the name more than 5 characters");

            RuleFor(x => x.Title).MaximumLength(60).WithMessage("Enter the role less than 60 characters");
            RuleFor(X => X.Title).MinimumLength(4).WithMessage("Enter the role more than 4 characters");


        }
    }
}
