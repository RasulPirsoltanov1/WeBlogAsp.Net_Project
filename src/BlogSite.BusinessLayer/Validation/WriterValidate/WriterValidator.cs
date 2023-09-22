using BlogSite.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Validation.WriterValidate
{
	public class WriterValidator:AbstractValidator<Writer>
	{
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.About).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(x => x.Mail).EmailAddress().NotNull().NotEmpty().MinimumLength(3);
		}
    }
}
