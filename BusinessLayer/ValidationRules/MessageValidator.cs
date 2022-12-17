using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Contact>
    {
        public MessageValidator()
        {
            RuleFor(x=>x.Message).MinimumLength(15).WithMessage("Your message is too short!");
            RuleFor(x=>x.Message).MaximumLength(200).WithMessage("Your message is too long");

        }
    }
}
