using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(x => x.Name).Matches(@"^[a-zA-Z]+$").WithMessage("Use only alphabetical characters");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message is required!");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Enter your name more than 3 character!");
            RuleFor(x => x.Message).MinimumLength(10).WithMessage("Enter your name more than 10 character!");
            RuleFor(x => x.Message).MaximumLength(50).WithMessage("Enter your name more than 50 character!");


        }
    }
}
